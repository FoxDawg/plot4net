using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PlottingLib.Enum;

namespace TestApplication.Core
{
    public class FigureExporter
    {
        private readonly Canvas canvas;
        private readonly RendererType rendererType;
        private readonly double resolution;

        public FigureExporter(Canvas canvas, RendererType rendererType, double resolution)
        {
            this.canvas = canvas;
            this.rendererType = rendererType;
            this.resolution = resolution;
        }

        public Task ExportToFileAsync(string fullPath)
        {
            var encoder = this.GetEncoder();

            if (encoder == null)
            {
                return Task.CompletedTask;
            }

            var renderTargetBitmap = this.GetRenderTargetBitmap();

            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            var memoryStream = this.SaveToStream(encoder);

            return File.WriteAllBytesAsync(fullPath, memoryStream.ToArray());
        }

        private MemoryStream SaveToStream(BitmapEncoder encoder)
        {
            var memoryStream = new MemoryStream();
            encoder.Save(memoryStream);
            memoryStream.Close();

            return memoryStream;
        }

        private BitmapEncoder GetEncoder()
        {
            return this.rendererType switch
            {
                RendererType.None => null,
                RendererType.Bmp => new BmpBitmapEncoder(),
                RendererType.Png => new PngBitmapEncoder(),
                RendererType.Jpeg => new JpegBitmapEncoder(),
                RendererType.Tiff => new TiffBitmapEncoder(),
                _ => throw new NotSupportedException($"The type {this.rendererType} is not yet supported for this operation.")
            };
        }

        private RenderTargetBitmap GetRenderTargetBitmap()
        {
            var dpiScale = VisualTreeHelper.GetDpi(this.canvas);

            var rect = new Rect(this.canvas.Margin.Left, this.canvas.Margin.Top, this.canvas.ActualWidth * dpiScale.DpiScaleX, this.canvas.ActualHeight * dpiScale.DpiScaleY);

            var renderTargetBitmap = new RenderTargetBitmap((int) rect.Right,
                (int) rect.Bottom, this.resolution, this.resolution, PixelFormats.Default);
            renderTargetBitmap.Render(this.canvas);

            return renderTargetBitmap;
        }
    }
}
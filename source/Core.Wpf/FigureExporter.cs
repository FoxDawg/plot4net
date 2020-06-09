using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using plot4net.Core.Enum;

namespace plot4net.Core.Wpf
{
    /// <summary>
    ///     The exporter for the drawn figure.
    /// </summary>
    public class FigureExporter
    {
        private readonly Canvas canvas;
        private readonly RendererType rendererType;
        private readonly double resolution;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FigureExporter" />
        /// </summary>
        /// <param name="canvas">The canvas to export.</param>
        /// <param name="rendererType">The renderer type to use.</param>
        /// <param name="resolution">The resolution to use.</param>
        public FigureExporter(Canvas canvas, RendererType rendererType, double resolution)
        {
            this.canvas = canvas ?? throw new ArgumentNullException(nameof(canvas));
            this.rendererType = rendererType;
            this.resolution = resolution;
        }

        /// <summary>
        ///     Exports the given canvas to a file.
        /// </summary>
        /// <param name="fullPath">Full path to the final image.</param>
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

            File.WriteAllBytes(fullPath, memoryStream.ToArray());
            return Task.CompletedTask;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PlottingLib;
using PlottingLib.Contract;
using PlottingLib.Enum;
using TestApplication.Core.Plotter;

namespace TestApplication.Core
{
    /// <summary>
    ///     Interaction logic for FigureControl.xaml
    /// </summary>
    public partial class FigureControl : UserControl
    {
        private ISimplePlot axisPlotter;
        private FigureExporter figureExporter;
        private IDataPlot scatterPlotter;
        private ISimplePlot titlePlotter;


        public static readonly DependencyProperty FigureProperty = DependencyProperty.Register(
            "Figure", typeof(Figure), typeof(FigureControl), new PropertyMetadata(default(Figure), FigureChangedCallback));

        public Figure Figure
        {
            get { return (Figure) this.GetValue(FigureProperty); }
            set { this.SetValue(FigureProperty, value); }
        }

        public FigureControl()
        {
            this.InitializeComponent();
        }

        private static void FigureChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FigureControl @this)
            {
                @this.UpdateFigure();
            }
        }

        private void UpdateFigure()
        {
            this.BaseCanvas.Children.Clear();
            this.BaseCanvas.Background = new SolidColorBrush(ColorConverter.ToWindowsMedia(this.Figure.FigureOptions.Background));

            this.figureExporter = new FigureExporter(this.BaseCanvas, this.Figure.FigureOptions.RendererType, this.Figure.FigureOptions.RendererResolution);
            this.Figure.ExportAction = s => this.figureExporter.ExportToFileAsync(s);

            this.titlePlotter = new TitlePlotter(this.BaseCanvas, this.Figure.FigureOptions);
            this.titlePlotter.Plot();

            this.axisPlotter = new AxisPlotter(this.BaseCanvas, this.Figure.FigureOptions);
            this.axisPlotter.Plot();


            switch (this.Figure.PlotOptions.LineType)
            {
                case LineType.Scatter:
                    this.PerformScatterPlot();
                    break;
                case LineType.ScatterAndLine:
                    this.PerformScatterPlot();
                    break;
            }
        }

        private void PerformScatterPlot()
        {
            this.scatterPlotter = new ScatterPlotter(this.BaseCanvas, this.Figure.FigureOptions, this.Figure.PlotOptions);
            this.scatterPlotter.Plot(this.Figure.XData, this.Figure.YData);
        }
    }
}
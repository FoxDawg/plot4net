using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PlottingControls.Framework.Plotter;
using PlottingLib;
using PlottingLib.Contract;
using PlottingLib.Helper;

namespace PlottingControls.Framework
{
    /// <summary>
    ///     Interaction logic for FigureControl.xaml
    /// </summary>
    public partial class FigureControl : UserControl
    {
        private IEnumerable<IDataPlot> dataPlotter;
        private FigureExporter figureExporter;

        private IEnumerable<ISimplePlot> simplePlotter;

        /// <summary>
        ///     The figure of the control.
        /// </summary>
        public static readonly DependencyProperty FigureProperty = DependencyProperty.Register(
            "Figure", typeof(Figure), typeof(FigureControl), new PropertyMetadata(default(Figure), FigureChangedCallback));

        /// <summary>
        ///     The figure of the control.
        /// </summary>
        public Figure Figure
        {
            get { return (Figure) this.GetValue(FigureProperty); }
            set { this.SetValue(FigureProperty, value); }
        }

        /// <summary>
        ///     Initializes a new instance of the figure control.
        /// </summary>
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

            RangeExtender.ExtendHorizontalRange(this.Figure.XData, this.Figure.FigureOptions.AxisOptions);
            RangeExtender.ExtendVerticalRange(this.Figure.YData, this.Figure.FigureOptions.AxisOptions);

            var factory = new PlotterFactory(this.Figure.FigureOptions);

            this.dataPlotter = factory.Create(this.Figure.PlotOptions);
            this.PerformSimplePlots(factory);
            this.PerformDataPlots(factory);
        }

        private void PerformSimplePlots(PlotterFactory factory)
        {
            this.simplePlotter = factory.Create();
            foreach (var simplePlot in this.simplePlotter)
            {
                simplePlot.Plot(this.BaseCanvas);
            }
        }

        private void PerformDataPlots(PlotterFactory factory)
        {
            this.dataPlotter = factory.Create(this.Figure.PlotOptions);
            foreach (var dataPlot in this.dataPlotter)
            {
                dataPlot.Plot(this.BaseCanvas, this.Figure.XData, this.Figure.YData);
            }
        }
    }
}
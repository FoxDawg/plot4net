using System.IO;
using System.Threading.Tasks;
using Common.Commands;
using Common.ViewModel;
using PlottingLib;
using PlottingLib.Options;

namespace TestApplication.Framework
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Figure figure;

        public Figure Figure
        {
            get { return this.figure; }
            set { this.SetProperty(ref this.figure, value); }
        }

        public IAsyncDelegateCommand PlotCommand { get; }
        public IAsyncDelegateCommand ExportCommand { get; }

        public MainWindowViewModel()
        {
            this.PlotCommand = new AsyncDelegateCommand(this.PlotAsync);
            this.ExportCommand = new AsyncDelegateCommand(this.ExportAsync);
        }

        private Task PlotAsync()
        {
            var xData = new double[] {-1, 1, 2, 3, 4, 5, 6};
            var yData = new double[] {-1, 10, 20, 10, -100, 10, -20};
            this.Figure = new Figure(new FigureOptions(){AxisOptions = new AxisOptions(){XLabel = "MyFooX", YLabel = "MyFooY", NumberOfTicks = 12}});
            this.Figure.Plot(new Plot(xData, yData, new PlotOptions()));

            xData = new double[] {1, 2, 3, 4};
            yData = new double[] {1, -2, 3, 4};

            this.Figure.Plot(new Plot(xData, yData, new PlotOptions()));

            return Task.CompletedTask;
        }

        private Task ExportAsync()
        {
            var fullPath = Path.GetFullPath(@"C:/temp/myImage.png");
            return this.Figure.ExportAsync(fullPath);
        }
    }
}
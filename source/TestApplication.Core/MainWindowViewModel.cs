using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Commands;
using Common.ViewModel;
using PlottingLib;

namespace TestApplication.Core
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
            var xData = Enumerable.Range(0, 100).Select(o => (double) o).ToArray();
            var random = new Random();
            var yData = xData.Select(o => o + random.Next(-50, 50)).Select(o => o).ToArray();
            this.Figure = new Figure(xData, yData);
            return Task.CompletedTask;
        }

        private Task ExportAsync()
        {
            var fullPath = Path.GetFullPath(@"C:/temp/myImage.png");
            return this.Figure.ExportAction.Invoke(fullPath);
        }
    }
}
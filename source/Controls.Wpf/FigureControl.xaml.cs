using System.Windows;
using System.Windows.Controls;

using plot4net.Core;
using plot4net.Core.Wpf;

namespace plot4net.Controls.Wpf
{
    /// <summary>
    /// Interaction logic for FigureControl.xaml
    /// </summary>
    public partial class FigureControl : UserControl
    {
        /// <summary>
        /// The figure of the control.
        /// </summary>
        public static readonly DependencyProperty FigureProperty = DependencyProperty.Register(
            "Figure", typeof(Figure), typeof(FigureControl), new PropertyMetadata(default(Figure), FigureChangedCallback));

        /// <summary>
        /// The figure of the control.
        /// </summary>
        public Figure Figure
        {
            get
            {
                return (Figure)this.GetValue(FigureProperty);
            }
            set
            {
                this.SetValue(FigureProperty, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the figure control.
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
            this.Figure.SetManager(new PlotManager(this.BaseCanvas, this.Figure.FigureOptions));
        }
    }
}
# plot4net
.NET plotting library

Provides access to simple plotting tools to draw 2D data plots.

The current implementation supports drawing in WPF.Framework projects.

In XAML, embed a usercontrol `<FigureControl Figure="{Binding MyFigure}" />` with a binding to your viewmodel Figure.
In your viewmodel, create a new Figure:
```
this.Figure = new Figure();
this.Figure.Plot(new Plot(new double[]{1,2}, new double[]{2,3}, new PlotOptions()));
```
You can change labels, title, ranges, colors in FigureOptions and AxisOptions.
You can add plots to the same figure, change line types and colors in the PlotOptions upon drawing.
To export a figure, call `this.Figure.ExportAsync(pathToFile)`.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Domain.ScatterPlots;
using DataExplorer.Presentation.Core.Canvas.Items;

namespace DataExplorer.Presentation.Views.ScatterPlots.AxisGridLines.Renderers
{
    public interface IXAxisGridLineRenderer
    {
        IEnumerable<CanvasLine> Render(IEnumerable<AxisLine> axisLines, Rect viewExtent, Size controlSize);
    }
}
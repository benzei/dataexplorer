﻿using System.Collections.Generic;
using System.Windows;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views.ScatterPlots.Events;

namespace DataExplorer.Domain.Views.ScatterPlots
{
    public class ScatterPlot : View, IScatterPlot
    {
        private Rect _viewExtent;
        private List<Plot> _plots;
        private readonly ScatterPlotLayout _layout;

        public ScatterPlot()
        {
            _viewExtent = new Rect(-0.1, -0.1, 1.2, 1.2);
            _plots = new List<Plot>();
            _layout = new ScatterPlotLayout();
        }

        public ScatterPlot(ScatterPlotLayout layout, Rect viewExtent, List<Plot> plots)
        {
            _viewExtent = viewExtent;
            _plots = plots;
            _layout = layout;
        }

        public Rect GetViewExtent()
        {
            return _viewExtent;
        }

        public void SetViewExtent(Rect viewExtent)
        {
            _viewExtent = viewExtent;

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }

        public List<Plot> GetPlots()
        {
            return _plots;
        }

        public ScatterPlotLayout GetLayout()
        {
            return _layout;
        }

        public void SetPlots(List<Plot> plots)
        {
            _plots = plots;

            DomainEvents.Raise(new ScatterPlotChangedEvent());
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataExplorer.Application.Core.Commands;

namespace DataExplorer.Application.Views.ScatterPlots.Commands
{
    public class ZoomOutCommand : ICommand
    {
        private readonly Point _center;

        public ZoomOutCommand(Point center)
        {
            _center = center;
        }

        public Point Center
        {
            get { return _center; }
        }
    }
}

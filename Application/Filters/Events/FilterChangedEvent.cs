﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Events;
using DataExplorer.Domain.Filters;

namespace DataExplorer.Application.Filters.Events
{
    public class FilterChangedEvent : FilterEvent
    {
        public FilterChangedEvent(Filter filter) : base(filter)
        {
        }
    }
}

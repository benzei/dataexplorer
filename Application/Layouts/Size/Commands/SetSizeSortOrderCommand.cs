﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Core.Commands;
using DataExplorer.Application.Layouts.Base.Commands;
using DataExplorer.Domain.Layouts;

namespace DataExplorer.Application.Layouts.Size.Commands
{
    public class SetSizeSortOrderCommand : BaseSetLayoutSortOrderCommand
    {
        public SetSizeSortOrderCommand(SortOrder sortOrder) : base(sortOrder)
        {
        }
    }
}

﻿using DataExplorer.Application.Columns;

namespace DataExplorer.Application.ScatterPlots.Layouts.Queries
{
    public interface IGetXColumnQuery
    {
        ColumnDto Query();
    }
}
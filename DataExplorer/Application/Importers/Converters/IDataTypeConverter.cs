﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Application.Importers.Converters
{
    public interface IDataTypeConverter
    {
        object Convert(object source);
    }
}

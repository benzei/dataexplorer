﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExplorer.Domain.Maps.LabelMaps
{
    public class BooleanToLabelMap : LabelMap
    {
        public override string Map(object value)
        {
            if (value == null)
                return "Null";

            return (bool) value 
                ? "True" 
                : "False";
        }
    }
}

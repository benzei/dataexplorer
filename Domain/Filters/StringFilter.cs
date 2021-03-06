﻿using System;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Predicates;
using DataExplorer.Domain.Rows;

namespace DataExplorer.Domain.Filters
{
    public class StringFilter : Filter
    {
        protected string _value;
        
        public StringFilter(Column column, string value, bool includeNull)
            : base(column, includeNull)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override Func<Row, bool> CreatePredicate()
        {
            return _column.HasNulls
                ? new NullableStringPredicate()
                    .Create(_column, _value, _includeNull)
                : new StringPredicate()
                    .Create(_column,_value);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using DataExplorer.Domain.Filters;
using DataExplorer.Domain.FilterTrees;
using DataExplorer.Domain.Tests.Filters;

namespace DataExplorer.Domain.Tests.FilterTrees
{
    public class FakeFilterTreeNode : FilterTreeNode
    {
        private readonly Filter _filter;

        public FakeFilterTreeNode() : base(null, null)
        {
            
        }

        public FakeFilterTreeNode(string name, Column column) : base(name, column)
        {
        }

        public FakeFilterTreeNode(FakeFilter filter) : base(null, null)
        {
            _filter = filter;
        }

        public FakeFilterTreeNode(string name, Column column, Filter filter) : base(name, column)
        {
            _filter = filter;
        }

        public override IEnumerable<FilterTreeNode> CreateChildren()
        {
            throw new NotImplementedException();
        }

        public override Filter CreateFilter()
        {
            return _filter;
        }
    }
}

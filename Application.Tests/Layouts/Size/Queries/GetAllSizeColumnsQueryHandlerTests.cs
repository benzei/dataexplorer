﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using DataExplorer.Application.Layouts.Size.Queries;
using DataExplorer.Application.Tests.Layouts.Base.Queries;
using DataExplorer.Domain.Tests.Columns;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Layouts.Size.Queries
{
    [TestFixture]
    public class GetAllSizeColumnsQueryHandlerTests
        : BaseGetAllLayoutColumnsQueryHandlerTests
    {
        private GetAllSizeColumnsQueryHandler _handler;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            _handler = new GetAllSizeColumnsQueryHandler(
                _mockRepository.Object,
                _mockAdapter.Object);
        }

        [Test]
        [TestCase(typeof(Boolean))]
        [TestCase(typeof(DateTime))]
        [TestCase(typeof(Double))]
        [TestCase(typeof(Int32))]
        [TestCase(typeof(String))]
        public void TestExecuteShouldIncludeColumnTypes(Type type)
        {
            var column = new ColumnBuilder()
                .WithDataType(type)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllSizeColumnsQuery());
            Assert.That(result.Single(), Is.EqualTo(_columnDto));
        }

        [Test]
        [TestCase(typeof(BitmapImage))]
        public void TestExecuteShouldExcludeColumnTypes(Type type)
        {
            var column = new ColumnBuilder()
                .WithDataType(type)
                .Build();
            base.SetUpColumn(column);
            var result = _handler.Execute(new GetAllSizeColumnsQuery());
            Assert.That(result, Is.Empty);
        }
    }
}

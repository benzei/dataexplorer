﻿using System.Collections.Generic;
using DataExplorer.Domain.Columns;
using NUnit.Framework;

namespace DataExplorer.Domain.Tests.Columns
{
    [TestFixture]
    public class ColumnTests
    {
        private Column _column;

        [SetUp]
        public void SetUp()
        {
            _column = new Column(1, 0, "Test", typeof(bool), new List<object> { 0, 1000, null });
        }

        [Test]
        public void TestGetIdShouldReturnId()
        {
            var result = _column.Id;
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestGetIndexShouldReturnIndex()
        {
            var result = _column.Index;
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestGetNameShouldReturnName()
        {
            var result = _column.Name;
            Assert.That(result, Is.EqualTo("Test"));
        }

        [Test]
        public void TestGetTypeShouldReturnType()
        {
            var result = _column.Type;
            Assert.That(result, Is.EqualTo(typeof(bool)));
        }

        [Test]
        public void TestHasNullsShouldReturnHasNulls()
        {
            var result = _column.HasNulls;
            Assert.That(result, Is.True);
        }
    }
}
﻿using System.Linq;
using DataExplorer.Application.Views.ScatterPlots.Axes.Factories.BooleanGridLines;
using DataExplorer.Domain.Layouts;
using DataExplorer.Domain.Maps.AxisMaps;
using NUnit.Framework;

namespace DataExplorer.Application.Tests.Views.ScatterPlots.Axes.Factories.BooleanGridLines
{
    [TestFixture]
    public class BooleanAxisGridLineFactoryTests
    {
        private BooleanGridLineFactory _factory;
        private AxisMap _map;

        [SetUp]
        public void SetUp()
        {
            _map = new BooleanToAxisMap(0d, 1d, SortOrder.Ascending);

            _factory = new BooleanGridLineFactory();
        }

        [Test]
        public void TestCreateShouldReturnFalseGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d).ToList();
            Assert.That(results.First().LabelName, Is.EqualTo("False"));
            Assert.That(results.First().Position, Is.EqualTo(0d));
        }

        [Test]
        public void TestCreateShouldReturnTrueGridLine()
        {
            var results = _factory.Create(_map, 0d, 1d).ToList();
            Assert.That(results.Last().LabelName, Is.EqualTo("True"));
            Assert.That(results.Last().Position, Is.EqualTo(1d));
        }

        [Test]
        public void TestCreateShouldReverseGridLineIfDescendingSortOrder()
        {
            var map = new BooleanToAxisMap(0d, 1d, SortOrder.Descending);
            var results = _factory.Create(map, 0d, 1d).ToList();
            Assert.That(results.First().LabelName, Is.EqualTo("False")); 
            Assert.That(results.Last().LabelName, Is.EqualTo("True"));
        }
    }
}

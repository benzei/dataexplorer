﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Messages;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Commands;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Events;
using DataExplorer.Application.Views.ScatterPlots.Layouts.Queries;
using DataExplorer.Domain.Core.Events;
using DataExplorer.Domain.Views.ScatterPlots.Events;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Core.Layout;

namespace DataExplorer.Presentation.Views.ScatterPlots.Layout.Color
{
    public class ColorLayoutViewModel 
        : BaseViewModel, 
        IColorLayoutViewModel,
        IEventHandler<LayoutChangedEvent>,
        IEventHandler<LayoutResetEvent>
    {
        private readonly IMessageBus _messageBus;

        public ColorLayoutViewModel(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public string Label
        {
            get { return "Color"; }
        }

        public IEnumerable<LayoutItemViewModel> Columns
        {
            get { return GetColumnViewModels(); }
        }

        public LayoutItemViewModel SelectedColumn
        {
            get { return GetSelectedColumnViewModel(); }
            set { SetSelectedColumnViewModel(value); }
        }

        public List<ColorPaletteViewModel> ColorPalettes
        {
            get { return GetColorPaletteViewModels(); }
        }

        public ColorPaletteViewModel SelectedColorPalette
        {
            get { return GetSelectedColorPaletteViewModel(); }
            set { SetSelectedColorPaletteViewModel(value); }
        }

        private List<LayoutItemViewModel> GetColumnViewModels()
        {
            var columns = _messageBus.Execute(new GetAllColumnsQuery());

            var viewModels = columns
                .Select(p => new LayoutItemViewModel(p))
                .ToList();

            return viewModels;
        }

        private LayoutItemViewModel GetSelectedColumnViewModel()
        {
            var columnDto = _messageBus.Execute(new GetColorColumnQuery());

            if (columnDto == null)
                return null;

            var viewModel = new LayoutItemViewModel(columnDto);

            return viewModel;
        }

        private void SetSelectedColumnViewModel(LayoutItemViewModel value)
        {
            // TODO: Should this just return or set X Column to null?
            if (value == null)
                return;

            var column = value.Column;

            _messageBus.Execute(new SetColorColumnCommand(column.Id));
        }

        private List<ColorPaletteViewModel> GetColorPaletteViewModels()
        {
            var colorPalettes = _messageBus.Execute(new GetAllColorPalettesQuery());

            var viewModels = colorPalettes
                .Select(p => new ColorPaletteViewModel(p))
                .ToList();

            return viewModels;
        }

        private ColorPaletteViewModel GetSelectedColorPaletteViewModel()
        {
            var colorPalette = _messageBus.Execute(new GetColorPaletteQuery());

            if (colorPalette == null)
                return null;

            var viewModel = new ColorPaletteViewModel(colorPalette);

            return viewModel;
        }

        private void SetSelectedColorPaletteViewModel(ColorPaletteViewModel viewModel)
        {
            if (viewModel == null)
                return;

            var colorPalette = viewModel.ColorPalette;

            _messageBus.Execute(new SetColorPaletteCommand(colorPalette));
        }

        public void Handle(LayoutChangedEvent args)
        {
            OnPropertyChanged(() => SelectedColumn);
        }

        public void Handle(LayoutResetEvent args)
        {
            OnPropertyChanged(() => Columns);
            OnPropertyChanged(() => SelectedColumn);
        }
    }
}
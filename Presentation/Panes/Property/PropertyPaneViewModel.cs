﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application;
using DataExplorer.Application.Columns.Queries;
using DataExplorer.Application.Core.Events;
using DataExplorer.Application.Core.Queries;
using DataExplorer.Application.Importers.CsvFiles.Events;
using DataExplorer.Application.Projects.Events;
using DataExplorer.Application.Rows.Events;
using DataExplorer.Application.Rows.Queries;
using DataExplorer.Presentation.Core;

namespace DataExplorer.Presentation.Panes.Property
{
    public class PropertyPaneViewModel 
        : BaseViewModel,
        IPropertyPaneViewModel,
        IEventHandler<SelectedRowsChangedEvent>,
        IEventHandler<ProjectOpenedEvent>,
        IEventHandler<ProjectClosedEvent>,
        IEventHandler<SourceImportedEvent>
    {
        private readonly IQueryBus _queryBus;
        private readonly IProcess _process;

        public PropertyPaneViewModel(
            IQueryBus queryBus, 
            IProcess process)
        {
            _queryBus = queryBus;
            _process = process;
        }

        public IEnumerable<IPropertyViewModel> Properties
        {
            get
            {
                var row = _queryBus.Execute(new GetLastSelectedRowQuery());

                if (row == null)
                    return new List<PropertyViewModel>();

                var fields = row.Fields.ToList();

                var columns = _queryBus.Execute(new GetAllColumnsQuery());

                return columns.Select(p => new PropertyViewModel(
                    p.Name,
                    GetDisplayValue(p.Index, fields),
                    _process));
            }
        }

        private string GetDisplayValue(int index, List<object> fields)
        {
            var field = fields[index];

            if (field == null)
                return string.Empty;

            return field.ToString();
        }

        public void Handle(SelectedRowsChangedEvent args)
        {
            OnPropertyChanged(() => Properties);
        }

        public void Handle(ProjectOpenedEvent args)
        {
            OnPropertyChanged(() => Properties);
        }

        public void Handle(ProjectClosedEvent args)
        {
            OnPropertyChanged(() => Properties);
        }

        public void Handle(SourceImportedEvent args)
        {
            OnPropertyChanged(() => Properties);
        }
    }
}

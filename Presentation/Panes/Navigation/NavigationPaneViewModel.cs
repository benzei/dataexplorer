﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataExplorer.Application.Application;
using DataExplorer.Application.Application.Events;
using DataExplorer.Application.Core.Events;
using DataExplorer.Presentation.Core;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;

namespace DataExplorer.Presentation.Panes.Navigation
{
    public class NavigationPaneViewModel 
        : BaseViewModel,
        INavigationPaneViewModel,
        IEventHandler<StartMenuVisibilityChangedEvent>,
        IEventHandler<NavigationTreeVisibilityChangedEvent>
    {
        private readonly IStartMenuViewModel _startMenuViewModel;
        private readonly INavigationTreeViewModel _navigationTreeViewModel;
        private readonly IApplicationStateService _stateService;

        public NavigationPaneViewModel(
            IStartMenuViewModel startMenuViewModel, 
            INavigationTreeViewModel navigationTreeViewModel, 
            IApplicationStateService stateService)
        {
            _startMenuViewModel = startMenuViewModel;
            _navigationTreeViewModel = navigationTreeViewModel;
            _stateService = stateService;
        }

        public bool IsStartMenuVisible
        {
            get { return _stateService.GetIsStartMenuVisible(); }
        }

        public IStartMenuViewModel StartMenuViewModel
        {
            get { return _startMenuViewModel; }
        }

        public bool IsNavigationTreeVisible
        {
            get { return _stateService.GetIsNavigationTreeVisible(); }
        }

        public INavigationTreeViewModel NavigationTreeViewModel
        {
            get { return _navigationTreeViewModel; }
        }

        public void Handle(StartMenuVisibilityChangedEvent args)
        {
            OnPropertyChanged(() => IsStartMenuVisible);
        }

        public void Handle(NavigationTreeVisibilityChangedEvent args)
        {
            OnPropertyChanged(() => IsNavigationTreeVisible);
        }
    }
}

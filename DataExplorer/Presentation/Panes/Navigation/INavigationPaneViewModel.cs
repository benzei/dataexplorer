﻿using System.ComponentModel;
using DataExplorer.Application.Application;
using DataExplorer.Presentation.Panes.Navigation.NavigationTree;
using DataExplorer.Presentation.Panes.Navigation.StartMenu;

namespace DataExplorer.Presentation.Panes.Navigation
{
    public interface INavigationPaneViewModel
    {
        bool IsStartMenuVisible { get; }
        IStartMenuViewModel StartMenuViewModel { get; }
        bool IsNavigationTreeVisible { get; }
        INavigationTreeViewModel NavigationTreeViewModel { get; }
        void Handle(ApplicationStateChangedEvent args);
        event PropertyChangedEventHandler PropertyChanged;
    }
}
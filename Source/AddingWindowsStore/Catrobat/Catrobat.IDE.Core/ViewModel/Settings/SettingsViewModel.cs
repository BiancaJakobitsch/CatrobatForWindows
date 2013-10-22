﻿using System.Diagnostics;
using System.Globalization;
using System.Windows;
using Catrobat.IDE.Core.UI;
using Catrobat.IDE.Core.Services;
using Catrobat.IDE.Core.Resources.Localization;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace Catrobat.IDE.Core.ViewModel.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Private Members

        private ThemeChooser _themeChooser;

        #endregion

        #region Properties

        public ThemeChooser ThemeChooser
        {
            get { return _themeChooser; }
            set { _themeChooser = value; RaisePropertyChanged(() => ThemeChooser); }
        }

        public bool ShowMemoryMonitorOption
        {
            get { return Debugger.IsAttached; }
        }

        public CultureInfo CurrentCulture
        {
            get { return ServiceLocator.CulureService.GetCulture(); }

            set
            {
                if (ServiceLocator.CulureService.GetCulture().Equals(value))
                {
                    return;
                }

                ServiceLocator.CulureService.SetCulture(value);
                //Thread.CurrentThread.CurrentUICulture = value;

                // todo: portable
                ((LocalizedStrings)ServiceLocator.LocalizedStrings).Reset();
                RaisePropertyChanged(() => CurrentCulture);
            }
        }

        #endregion

        #region Commands

        public RelayCommand ShowDesignSettingsCommand { get; private set; }

        public RelayCommand ShowBrickSettingsCommand { get; private set; }

        public RelayCommand ShowLanguageSettingsCommand { get; private set; }

        #endregion

        #region Actions

        private static void ShowDesignSettingsAction()
        {
            ServiceLocator.NavigationService.NavigateTo(typeof(SettingsThemeViewModel));
        }

        private static void ShowBrickSettingsAction()
        {
            ServiceLocator.NavigationService.NavigateTo(typeof(SettingsBrickViewModel));
        }

        private static void ShowLanguageSettingsAction()
        {
            ServiceLocator.NavigationService.NavigateTo(typeof(SettingsLanguageViewModel));
        }

        #endregion

        #region MessageActions

        private void ThemeChooserInitializedMessageAction(GenericMessage<ThemeChooser> message)
        {
            ThemeChooser = message.Content;
        }

        #endregion

        public SettingsViewModel()
        {
            ShowDesignSettingsCommand = new RelayCommand(ShowDesignSettingsAction);
            ShowBrickSettingsCommand = new RelayCommand(ShowBrickSettingsAction);
            ShowLanguageSettingsCommand = new RelayCommand(ShowLanguageSettingsAction);

            Messenger.Default.Register<GenericMessage<ThemeChooser>>(this,
                 ViewModelMessagingToken.ThemeChooserListener, ThemeChooserInitializedMessageAction);
        }
    }
}
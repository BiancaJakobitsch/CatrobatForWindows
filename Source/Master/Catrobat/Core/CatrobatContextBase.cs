﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Catrobat.Core.Annotations;
using Catrobat.Core.Misc;
using Catrobat.Core.Misc.Helpers;
using Catrobat.Core.Objects;

namespace Catrobat.Core
{
    public abstract class CatrobatContextBase : INotifyPropertyChanged
    {

        #region Constants

        public const string PlayerActiveProjectZipPath = "ActivePlayerProject/ActiveProject.catrobat_from_ide";
        public const string LocalSettingsFilePath = "Settings/settings";
        public const string DefaultProjectPath = "default.catrobat";
        public const string ProjectsPath = "Projects";
        public const string DefaultProjectName = "DefaultProject";
        public const string TempProjectImportZipPath = "Temp/ImportProjectZip";
        public const string TempProjectImportPath = "Temp/ImportProject";
        public const string TempPaintImagePath = "Temp/PaintImage";

        #endregion

        #region Private members

        private Project _currentProject;

        #endregion

        #region Properties

        public LocalSettings LocalSettings { get; set; }

        public string CurrentToken
        {
            get { return LocalSettings.CurrentToken; }

            set
            {
                if (LocalSettings.CurrentToken == value) return;

                LocalSettings.CurrentToken = value;
                RaisePropertyChanged();
            }
        }

        public string CurrentUserEmail
        {
            get { return LocalSettings.CurrentUserEmail; }

            set
            {
                if (LocalSettings.CurrentUserEmail == value) return;

                LocalSettings.CurrentUserEmail = value;
                RaisePropertyChanged();
            }
        }

        public Project CurrentProject
        {
            get { return _currentProject; }
            set
            {
                if (_currentProject == value) return;

                _currentProject = value;
                ProjectHolder.Project = _currentProject;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> selector)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNameHelper.GetPropertyNameFromExpression(selector)));
            }
        }

        #endregion
    }
}
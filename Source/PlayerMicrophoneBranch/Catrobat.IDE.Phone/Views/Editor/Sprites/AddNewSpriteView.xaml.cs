﻿using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Navigation;
using Catrobat.IDE.Core.Services;
using Catrobat.IDE.Core.ViewModel;
using Catrobat.IDE.Core.ViewModel.Editor.Sprites;
using Microsoft.Phone.Controls;

namespace Catrobat.IDE.Phone.Views.Editor.Sprites
{
    public partial class AddNewSpriteView : PhoneApplicationPage
    {
        private readonly AddNewSpriteViewModel _viewModel = 
            ((ViewModelLocator)ServiceLocator.ViewModelLocator).AddNewSpriteViewModel;

        public AddNewSpriteView()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(() =>
                {
                    TextBoxSpriteName.Focus();
                    TextBoxSpriteName.SelectAll();
                });
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            _viewModel.GoBackCommand.Execute(null);
            e.Cancel = true;
            base.OnBackKeyPress(e);
        }

        private void TextBoxSpriteName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.SpriteName = TextBoxSpriteName.Text;
        }
    }
}
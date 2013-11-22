﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Catrobat.IDE.Phone.Content.Images.Application
{
    public partial class Logo : UserControl
    {
        public Visibility TextVisibility
        {
            get { return (Visibility)GetValue(IsTextVisibleProperty); }
            set { SetValue(IsTextVisibleProperty, value); }
        }

        public static readonly DependencyProperty IsTextVisibleProperty = DependencyProperty.Register(
            "TextVisibility", typeof(Visibility), typeof(Logo), new PropertyMetadata(TextVisibilityChanged));

        private static void TextVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Logo) d).PocketCodeText.Visibility = (Visibility)e.NewValue;
        }

        public double ScaleFactor
        {
            get { return (double)GetValue(ScaleFactorProperty); }
            set { SetValue(ScaleFactorProperty, value); }
        }

        public static readonly DependencyProperty ScaleFactorProperty = DependencyProperty.Register("ScaleFactor", typeof(double), typeof(Logo), new PropertyMetadata(0.0, ScaleFactorChanged));

        private static void ScaleFactorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var canvas = ((Logo) d).Main;
            var scaleFactor = (double) e.NewValue;

            canvas.Height = 100*scaleFactor;
            canvas.Width = 660*scaleFactor;


            canvas.RenderTransform = new ScaleTransform 
            { 
                ScaleX = scaleFactor, 
                ScaleY = scaleFactor,
            };
        }


        public Logo()
        {
            InitializeComponent();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Catrobat.Paint
{
    public static class PaintLauncher
    {
        public static BitmapImage CurrentImage { get; set; }

        public static void Launche()
        {
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri("/Paint;component/View/MainView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
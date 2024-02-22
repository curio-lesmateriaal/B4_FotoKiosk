using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace FotoKioskApp.Pages
{
    public sealed partial class PhotoPage : Page
    {
        public PhotoPage()
        {
            this.InitializeComponent();

            LoadPhotos();

            this.Loaded += PhotoPage_Loaded;
        }

        private async void PhotoPage_Loaded(object sender, RoutedEventArgs e)
        {
            await DebugHelper.ShowDialog(this, "Veel plezier en succes met dit project!");
        }

        private void LoadPhotos()
        {
            // TODO
        }
    }
}

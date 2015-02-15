using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool ForceClosing = true;
        public static string UserName { get; set; }
        public static string NickName { get; set; }

        public static Dictionary<int, BitmapImage> cardImages = new Dictionary<int, BitmapImage>();
    }
}

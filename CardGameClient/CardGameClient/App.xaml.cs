using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using CardGameServer;

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
        public static LoginScreen loginScreen { get; set; }

        public static bool isConnected = false;

        public static Dictionary<int, BitmapImage> cardImages = new Dictionary<int, BitmapImage>();
        public static Dictionary<int, BitmapImage> digitImages = new Dictionary<int, BitmapImage>();        
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using CardGameServer;
using System.Threading;

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

        public static Mutex ProxyMutex = new Mutex();

        public static bool InGame = false;

        public static Thread iamonlineTread;

        public static bool isConnected = false;

        public static List<Window> WindowList = new List<Window>();

        public static Dictionary<int, BitmapImage> cardImages = new Dictionary<int, BitmapImage>();
        public static Dictionary<int, BitmapImage> digitImages = new Dictionary<int, BitmapImage>();

        public static CharInfo charInfo;


        public static void iAmOnline()
        {
            while (true)
            {
                if (!App.InGame && App.isConnected)
                {
                    bool isError = false;

                    App.ProxyMutex.WaitOne();
                    try
                    {
                        ServiceProxy.Proxy.iAmOnline(App.UserName);
                    }
                    catch (Exception exc)
                    {
                        isError = true;
                        App.loginScreen.Dispatcher.Invoke(new Action(delegate
                        {
                            App.isConnected = false;
                            App.loginScreen.loginBtn.IsEnabled = true;
                            App.loginScreen.errorText.Content = "Связь с сервером неожиданно прервана...";
                            App.loginScreen.Show();
                        }));
                    }
                    App.ProxyMutex.ReleaseMutex();

                    if (isError)
                    {
                        App.OnConnectionError();
                        return;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public static void OnConnectionError()
        {
            Thread.Sleep(2000);
            App.loginScreen.Dispatcher.Invoke(new Action(delegate
            {
                App.isConnected = false;
                foreach (Window window in App.WindowList)
                {
                    try
                    {
                        App.ForceClosing = false;
                        window.Close();
                    }
                    catch { }
                }
            }));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CardGameServer;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for InGameMenuEscWindow.xaml
    /// </summary>
    public partial class InGameMenuEscWindow : Window
    {
        public InGameMenuEscWindow(Window own)
        {
            InitializeComponent();
            Owner = own;
        }

        private void CancelBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.WindowList.Remove(this.Name);
            Close();
        }

        private void LeaveBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {

            bool isError = false;
            if (App.isConnected && ServiceProxy.Proxy != null)
            {
                App.ProxyMutex.WaitOne();
                try
                {
                    ServiceProxy.Proxy.leaveGame(App.NickName);
                }
                catch
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        App.isConnected = false;
                        App.loginScreen.loginBtn.IsEnabled = true;
                        App.loginScreen.errorText.Content = "Связь с сервером неожиданно прервана...";
                        App.loginScreen.Show();
                    }));
                    isError = true;
                }
                App.ProxyMutex.ReleaseMutex();
            }

            if (isError)
            {
                App.OnConnectionError();
                return;
            }


            //App.ForceClosing = false;
            App.WindowList.Remove(this.Name);
            Owner.Hide();
            App.WindowList["LobbyWnd"].Show();
            Close();
        }

        private void ExitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.ForceClosing = true;
            App.WindowList["MainWnd"].Close();
            Close();
        }
    }
}

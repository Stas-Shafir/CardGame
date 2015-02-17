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
using System.Windows.Media.Animation;
using CardGameServer;
using System.ServiceModel;
using System.IO;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }


        private void loginBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string user = loginTextBox.Text;
                string pass = passwordTextBox.Password;

                if (user == "" || pass == "" || sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0                      ||  pass.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    errorText.Content = "Поля заполнены некорректно";
                    return;
                }

                ChannelFactory<Servicegame> cf =
                        new ChannelFactory<Servicegame>("MyEndpoint");

                ServiceProxy.Proxy = cf.CreateChannel();

                if (ServiceProxy.Proxy.Login(user, pass))
                {
                    App.UserName = user;
                    if (!ServiceProxy.Proxy.isAccountContainsAnyCharacter(loginTextBox.Text))
                    {
                        CharacterCreateScreen ccs = new CharacterCreateScreen(this);
                        ccs.Show();
                        Hide();
                    }
                    else
                    {
                        LobbyScreen ls = new LobbyScreen(this);
                        ls.Show();
                        Hide();
                    }
                }
                else
                {
                    errorText.Content = "Неверная пара логин-пароль либо поля заполнены некорректно";
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
            }
        }

        private void exitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in Directory.GetFiles("Images/Cards/", "*.png", SearchOption.AllDirectories))
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(item, UriKind.Relative);
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();


                App.cardImages.Add(Int32.Parse(System.IO.Path.GetFileNameWithoutExtension(item)), img);
            }
            
        }
    }
}

﻿using System;
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
using System.Threading;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        //login and password temp
        private string login, passw;
        //LoadingScreen ldscreen;

        public LoginScreen()
        {
            InitializeComponent();

            //ldscreen = new LoadingScreen();
            //ldscreen.Show();
        }


        private void Login()
        {
            try
            {
                ChannelFactory<Servicegame> cf =
                            new ChannelFactory<Servicegame>("MyEndpoint");

                ServiceProxy.Proxy = cf.CreateChannel();

                //0 success
                //1 incorrect pass
                //2 already online 
                //3 hacking attempt

                int res = ServiceProxy.Proxy.Login(login, passw);

                this.Dispatcher.Invoke(new Action(() => loginBtn.IsEnabled = true));

                if (res == 0)
                {
                    App.UserName = login;
                    App.isConnected = true;

                    App.iamonlineTread = new Thread(App.iAmOnline) { IsBackground = true };
                    App.iamonlineTread.Start();

                    bool isError = false;

                    bool contains = false;

                    App.ProxyMutex.WaitOne();
                    try
                    {
                        contains = ServiceProxy.Proxy.isAccountContainsAnyCharacter(login);
                    }
                    catch
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            App.isConnected = false;
                            loginBtn.IsEnabled = true;
                            errorText.Content = "Связь с сервером неожиданно прервана...";
                        }));
                        isError = true;
                    }

                    App.ProxyMutex.ReleaseMutex();

                    if (isError) return;


                    if (!contains)
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            if (!App.WindowList.ContainsKey("CharacterCreateWnd"))
                            {
                                CharacterCreateScreen ccs = new CharacterCreateScreen();
                                App.WindowList.Add(ccs.Name, ccs);
                            }
                            else
                                (App.WindowList["CharacterCreateWnd"] as CharacterCreateScreen).OnWindowShow();

                            App.WindowList["CharacterCreateWnd"].Show();
                            //loginTextBox.Text = "";
                            passwordTextBox.Password = "";
                            Hide();
                        }));
                    }
                    else
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            if (!App.WindowList.ContainsKey("LobbyWnd"))
                            {
                                LobbyScreen ls = new LobbyScreen();
                                App.WindowList.Add(ls.Name, ls);
                            }
                            else
                                (App.WindowList["LobbyWnd"] as LobbyScreen).OnWindowShow();

                            App.WindowList["LobbyWnd"].Show();
                            //loginTextBox.Text = "";
                            passwordTextBox.Password = "";
                            Hide();
                        }));

                        //Thread.Sleep(3000);

                        //this.Dispatcher.Invoke(new Action(() =>
                        //    Hide()
                        //));
                    }
                }
                else if (res == 1)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                       errorText.Content = "Неправельный логин или пароль!"
                   ));
                }
                else if (res == 2)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                        errorText.Content = "Кто-то другой использует ваш аккаунт! Если это не вы, смените пароль и обратитесь к администрации"
                    ));
                }
                else if (res == 3)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                       errorText.Content = "Поля заполнены некорректено!"
                   ));
                }
            }
            catch (CommunicationException)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    App.isConnected = false;
                    loginBtn.IsEnabled = true;
                    errorText.Content = "Подключение невозможно. Сервер выключен или недоступен. Попробуйте повторить попытку позже...";
                }));
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    App.isConnected = false;
                    loginBtn.IsEnabled = true;
                    App.dumpException(exc);
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                }));
            }
        }

        private void loginBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                login = loginTextBox.Text;
                passw = passwordTextBox.Password;

                if (login == "" || passw == "" 
                    || sqlInjection.Words.Any(word => login.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0
                    || passw.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    errorText.Content = "Поля заполнены некорректно";
                    return;
                }

                loginBtn.IsEnabled = false;

                Thread loginThread = new Thread(Login);
                loginThread.Start();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Критическая ошибка!");
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
           // ldscreen.Owner = this;
            try
            {
                App.WindowList.Add(this.Name, this);
                foreach (var item in Directory.GetFiles("Images/Cards/", "*.png", SearchOption.AllDirectories))
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(item, UriKind.Relative);
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.EndInit();


                    App.cardImages.Add(Int32.Parse(System.IO.Path.GetFileNameWithoutExtension(item)), img);
                }


                foreach (var item in Directory.GetFiles("Images/Numeric/", "*.png", SearchOption.AllDirectories))
                {
                    BitmapImage img = new BitmapImage();
                    img.BeginInit();
                    img.UriSource = new Uri(item, UriKind.Relative);
                    img.CacheOption = BitmapCacheOption.OnLoad;
                    img.EndInit();


                    App.digitImages.Add(Int32.Parse(System.IO.Path.GetFileNameWithoutExtension(item)), img);
                }

                App.rarityDictionary.Add(1, new Rarity("Обычное существо", Brushes.MintCream));
                App.rarityDictionary.Add(2, new Rarity("Необычное существо", Brushes.LightBlue));
                App.rarityDictionary.Add(3, new Rarity("Редкое существо", Brushes.DodgerBlue));
                App.rarityDictionary.Add(4, new Rarity("Мистическое существо", Brushes.DarkMagenta));
                App.rarityDictionary.Add(5, new Rarity("Легендарное существо", Brushes.DarkOrange));

                App.loginScreen = this;
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                    App.dumpException(exc);
                    Application.Current.Shutdown();
                }));     
            }
            
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void LoginWnd_ContentRendered(object sender, EventArgs e)
        {
            
        }

        
    }
}

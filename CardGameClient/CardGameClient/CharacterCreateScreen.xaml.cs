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
using CardGameServer;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for CharacterCreateScreen.xaml
    /// </summary>
    public partial class CharacterCreateScreen : Window
    {
        int CardIndex = -1;
        CardPlace selectedCardPlace;
        List<Card> templates = null;

        public CharacterCreateScreen()
        {
            InitializeComponent();
            errorPopupInfo.grid1.Margin = new Thickness(0, -35, 0, 35);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isError = false;
            if (App.isConnected && ServiceProxy.Proxy != null)
            {
                App.isConnected = false;
                App.ProxyMutex.WaitOne();
                try
                {
                    ServiceProxy.Proxy.Logout(App.UserName);
                }
                catch
                {
                    App.OnException();
                    isError = true;
                }
                App.ProxyMutex.ReleaseMutex();
            }

            if (App.ForceClosing)
                Application.Current.Shutdown();
            else if (isError)
            {
                App.OnConnectionError();
                return;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.ForceClosing = true;
        }

        private void exitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //logout
            App.ForceClosing = false;
            Window_Closing(this, null);
            Window_Closed(this, null);


            //show loginWnd
            App.WindowList["LoginWnd"].Show();

            new Action(delegate {

                Thread.Sleep(1000);

                this.Dispatcher.Invoke(new Action(delegate
                {
                    Hide();
                }));

            }).BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar) { }), null);


            //Close();
        }
        
        private void CreateCharacter()
        {
            try
            {
                bool isError = false;
                bool result = false;

                App.ProxyMutex.WaitOne();
                try
                {
                    result = ServiceProxy.Proxy.createCharacter(App.UserName, App.NickName, CardIndex);
                }
                catch
                {
                    App.OnException();
                    isError = true;
                }

                App.ProxyMutex.ReleaseMutex();

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }


                if (result)
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        App.WindowList["LoadingWnd"].Show();
                    }));

                    Thread.Sleep(2000);

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

                        /*selectedCardPlace.selected = false;
                        characterNameTextBox.Text = "";
                        CardIndex = -1;
                        errorText.Content = "Имя персонажа: Введите от 3 до 16 символов";*/

                        Hide();
                    }));

                    Thread.Sleep(2000);
                }

                else
                {
                    this.Dispatcher.Invoke(new Action( () =>
                        errorPopupInfo.ShowError("Ошибка при создании персонажа. Персонаж с таким именем уже существует...")
                    ));
                }
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action( delegate {
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                    App.isConnected = false;
                    App.dumpException(exc);
                    Application.Current.Shutdown();
                }));
            }
        }

        private void createCharBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string charName = characterNameTextBox.Text;

            if (charName == "" || sqlInjection.Words.Any(word => charName.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                errorPopupInfo.ShowError("Поле заполнено некорректно");
                return;
            }

            if (charName.Length <= 2 || charName.Length > 16)
            {
                errorPopupInfo.ShowError("Ошибка: Введите от 3 до 16 символов");
                return;
            }

            if (CardIndex == -1)
            {
                errorPopupInfo.ShowError("Вы забыли выбрать героя...");
                return;
            }

            App.NickName = charName;

            Thread createCharacter = new Thread(CreateCharacter) { IsBackground = true };
            createCharacter.Start();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                OnWindowShow();

               /* this.Dispatcher.Invoke(new Action(() =>
                    App.loginScreen.Hide()
                ), DispatcherPriority.ContextIdle, null);*/

            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                    App.isConnected = false;
                    App.dumpException(exc);
                    Application.Current.Shutdown();
                }));     
            }
        }


        public void OnWindowShow()
        {
            new Action(delegate
            {
                bool isError = false;

                App.ProxyMutex.WaitOne();
                try
                {
                    templates = ServiceProxy.Proxy.getHeroesTemplateAvailableList();
                }
                catch
                {
                    App.OnException();
                    isError = true;
                }

                App.ProxyMutex.ReleaseMutex();

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }
            }).Invoke();

            if (templates != null)
            {
                CardPlace cp;

                for (int i = 0; i < templates.Count; i++)
                {
                    Card item = templates[i];
                    cp = gridHeroes.Children[i] as CardPlace;
                    cp.ThisCard = item;
                    cp.IsEnabled = true;

                    CardInfo ci = new CardInfo();
                    ci.CardName.Content = item.card_name;
                    ci.Rarity.Content = App.rarityDictionary[item.cardRarity].RarityName;
                    ci.Rarity.Foreground = App.rarityDictionary[item.cardRarity].RarityColor;
                    ci.Dmg.Content = "Атака: " + item.dmg;
                    ci.Def.Content = "Защита: " + item.def;
                    ci.Hp.Content = "Здоровье: " + item.hp;
                    ci.Level.Content = "Уровень: " + item.min_level;

                    cp.ToolTip = new ToolTip()
                    {
                        Background = new SolidColorBrush(Color.FromArgb(230, 0, 0, 0)),
                        BorderThickness = new Thickness(0),
                        Content = ci
                    };
                }
            }
        }

        private void CardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;
            if (selectedCardPlace != null && selectedCardPlace != cp) selectedCardPlace.selected = false;
            CardIndex = cp.ThisCard.id;
            selectedCardPlace = cp;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            
        }

        private void CharacterCreateWnd_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Hidden)
            {
                if (selectedCardPlace != null) selectedCardPlace.selected = false;
                selectedCardPlace = null;
                characterNameTextBox.Text = "";
                CardIndex = -1;
                errorText.Content = "Имя персонажа: Введите от 3 до 16 символов";
            }
            
        }       
    }
}

using CardGameServer;
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
using System.Windows.Threading;
using System.Threading;
using System.ServiceModel;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for LobbyScreen.xaml
    /// </summary>
    public partial class LobbyScreen : Window
    {
        Thread findGameThread;

        public LobbyScreen(Window ownwin)
        {
            InitializeComponent();
            this.Owner = ownwin;
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
                    if (findBtn.InProgress)
                    {
                        ServiceProxy.Proxy.cancelSearch(App.NickName);
                    }
                    ServiceProxy.Proxy.Logout(App.UserName);
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
            App.ForceClosing = false;
            App.loginScreen.Show();
            Close();
        }

        public void UpdateInfo()
        {
            bool isError = false;
            CharInfo ch = null;

            App.ProxyMutex.WaitOne();
            try
            {
                ch = ServiceProxy.Proxy.EnterWorld(App.UserName);
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

            if (isError)
            {
                App.OnConnectionError();
                return;
            }

            NickNameLevel.Text = ch.nickname + ", " + ch.heroname + " " + ch.character_level + "-го уровня";
            Exp.Text = "Опыт: " + ch.exp;
            Games.Text = "Кол-во Игр: " + ch.games;
            Wins.Text = "Кол-во Побед: " + ch.wins;
            Rating.Text = "Ваш рейтинг: " + ch.rating;

            Thread updateRankingThread = new Thread(UpdateRanking) {IsBackground = true};
            updateRankingThread.Start();

        }

        private void UpdateRanking()
        {
            Thickness mrg = new Thickness(5, 5, 0, 5);


            bool isError = false;
            List<CharInfo> RankingList = null;

            App.ProxyMutex.WaitOne();
            try
            {
                RankingList = ServiceProxy.Proxy.getRanking();
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

            if (isError)
            {
                App.OnConnectionError();
                return;
            }

            this.Dispatcher.Invoke(new Action(delegate
                {
                    ratingGrid.Children.RemoveRange(6, ratingGrid.Children.Count - 6);

                    for (int i = 0; i < RankingList.Count; i++)
                    {
                        CharInfo currCharInf = RankingList[i];

                        Label tx = new Label()
                        {
                            Content = (i + 1).ToString(),
                            Foreground = Brushes.Wheat,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        ratingGrid.Children.Add(tx);
                        Grid.SetRow(tx, i + 1);
                        Grid.SetColumn(tx, 0);

                        tx = new Label()
                        {
                            Content = currCharInf.nickname,
                            Foreground = Brushes.Wheat,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        ratingGrid.Children.Add(tx);
                        Grid.SetRow(tx, i + 1);
                        Grid.SetColumn(tx, 1);


                        tx = new Label()
                        {
                            Content = currCharInf.heroname + " "
                                + currCharInf.character_level + "-го уровня",
                            Foreground = Brushes.Wheat,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center

                        };
                        ratingGrid.Children.Add(tx);
                        Grid.SetRow(tx, i + 1);
                        Grid.SetColumn(tx, 2);


                        tx = new Label()
                        {
                            Content = currCharInf.games.ToString(),
                            Foreground = Brushes.Wheat,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center

                        };
                        ratingGrid.Children.Add(tx);
                        Grid.SetRow(tx, i + 1);
                        Grid.SetColumn(tx, 3);


                        tx = new Label()
                        {
                            Content = currCharInf.wins.ToString(),
                            Foreground = Brushes.Wheat,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };
                        ratingGrid.Children.Add(tx);
                        Grid.SetRow(tx, i + 1);
                        Grid.SetColumn(tx, 4);
                    }
                }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isError = false;
                CharInfo ch = null;

                App.ProxyMutex.WaitOne();
                try
                {
                    ch = ServiceProxy.Proxy.EnterWorld(App.UserName);
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

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }

                
                App.NickName = ch.nickname;

                NickNameLevel.Text = ch.nickname + ", " + ch.heroname + " " + ch.character_level + "-го уровня";
                Exp.Text = "Опыт: " + ch.exp;
                Games.Text = "Кол-во Игр: " + ch.games;
                Wins.Text = "Кол-во Побед: " + ch.wins;
                Rating.Text = "Ваш рейтинг: " + ch.rating;

                Thread updateRankingThread = new Thread(UpdateRanking) { IsBackground = true };
                updateRankingThread.Start();            
                
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                    App.isConnected = false;
                    Application.Current.Shutdown();
                }));     
            }
        }

        private void OnGameEnd(object sender, System.ComponentModel.CancelEventArgs e)
        {          
            findBtn.Enabled = true;
            MainLobbyBackBtn.ToolTip = null;
            AllCardsBtn.ToolTip = null;
            App.InGame = false;
            Show();
            UpdateInfo();

        }
        //187 cnhjrf
        private void FindGame()
        {
            try
            {
                bool isError = false;
                Game game = null;

                App.ProxyMutex.WaitOne();
                try
                {
                    game = ServiceProxy.Proxy.findGame(App.NickName);
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

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }

                
                if (game == null)
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        MessageBox.Show("Некорректные данные или была обнаружена попытка взлома.\n"
                      + "Действие было записано...");
                        findBtn.InProgress = false;
                    }));

                    return;
                }

                App.InGame = true;

                this.Dispatcher.Invoke(new Action(delegate
                {
                    findBtn.Enabled = true;
                    findBtn.InProgress = true;
                }));

                if (game.gameState == 2)
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        findBtn.Enabled = false;
                        findBtn.textLabel.Content = "Противник найден...";
                    }));

                    Thread.Sleep(2000); //emulate find proccess

                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        findBtn.InProgress = false;
                        MainWindow mw = new MainWindow(this);

                        mw.Closing += OnGameEnd;
                        findBtn.Enabled = true;

                        mw.Show();
                        App.WindowList.Add(mw);
                    }));
                }
                else if (game.gameState == 1)
                {
                    while (true)
                    {
                        isError = false;

                        App.ProxyMutex.WaitOne();
                        try
                        {
                            game = ServiceProxy.Proxy.getGame(App.NickName);
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

                        if (isError)
                        {
                            App.OnConnectionError();
                            return;
                        }

                        if (game != null)
                        {
                            if (game.gameState == 2)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    findBtn.Enabled = false;
                                    findBtn.textLabel.Content = "Противник найден...";
                                }));

                                Thread.Sleep(2000); //emulate find proccess

                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    findBtn.InProgress = false;
                                    MainWindow mw = new MainWindow(this);
                                    mw.Closing += OnGameEnd;
                                    findBtn.Enabled = true;
                                    mw.Show();
                                    App.WindowList.Add(mw);
                                }));
                                break;
                            }
                            else if (game.gameState == 7) return;
                        }
                        else return;
                    }
                }

            }
            catch (CommunicationException exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message, "Критическая ошибка!");
                    App.isConnected = false;
                    Application.Current.Shutdown();
                }));
            }
        }

        private void findBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (findBtn.InProgress)
            {
                //findGameThread.Abort();
                findBtn.Enabled = false;

                bool isError = false;

                App.ProxyMutex.WaitOne();
                try
                {
                    ServiceProxy.Proxy.cancelSearch(App.NickName);
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

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }

                findBtn.InProgress = false;
                findBtn.Enabled = true;
                MainLobbyBackBtn.ToolTip = null;
                AllCardsBtn.ToolTip = null;
                App.InGame = false;
                return;
            }

            findBtn.Enabled = false;
            MainLobbyBackBtn.ToolTip = "Идёт поиск игры. Для того, чтобы выйти требуется его отменить...";
            AllCardsBtn.ToolTip = "Идёт поиск игры. Для того, чтобы выполнить данное действуе требуется его отменить...";
            findBtn.textLabel.Content = "Поиск противника...";

            findGameThread = new Thread(FindGame) { IsBackground = true };
            findGameThread.Start();
        }

        private void Window_ContentRendered_1(object sender, EventArgs e)
        { 
            Owner.Hide();
        }

        private void AllCardPlace_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;

            cp.selected = false;

            foreach (CardPlace item in SlotGrid.Children)
            {
                if (item.ContainsCard) continue;

                int oslot = cp.ThisCard.slot;
                int nslot = Int32.Parse(item.Tag.ToString());

                bool isError = false;

                bool res = false;

                App.ProxyMutex.WaitOne();
                try
                {

                    res = ServiceProxy.Proxy.ChangeCardslot(App.UserName, oslot, nslot);
                }
                catch (CommunicationException exc)
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

                if (isError)
                {
                    App.OnConnectionError();
                    return;
                }


                if (res)
                {
                    item.ThisCard = cp.ThisCard;
                    item.ThisCard.slot = nslot;
                    cp.ContainsCard = false;                    
                }

                return;

            }

            MessageBox.Show("Все боевые слоты уже заняты\nЧтобы переместить туда эту карту необходимо освободить один...");
        }

        private void SlotCardPlace_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public void GetAllCard()
        {
            bool isError = false;
            List<Card> allCards = null;

            App.ProxyMutex.WaitOne();
            try
            {
                allCards = ServiceProxy.Proxy.GetAllCard(App.UserName);
            }
            catch (CommunicationException exc)
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

            if (isError)
            {
                App.OnConnectionError();
                return;
            }

            if (allCards != null)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    foreach (var item in allCards)
                    {
                        CardPlace cp;
                        if (item.slot >= 10)
                        {
                            cp = AllCardsGrid.Children[item.slot - 10] as CardPlace;
                            cp.ThisCard = item;
                        }
                        else
                        {
                            cp = SlotGrid.Children[item.slot - 1] as CardPlace;
                            cp.ThisCard = item;
                        }
                    }
                }));
            }
        }

        private void MyCardsGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (MyCardsGrid.Visibility == Visibility.Visible)
            {
                Thread fillMyCardGridThread = new Thread(GetAllCard);
                fillMyCardGridThread.Start();
            }
        }

        private void AllCardsBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (findBtn.InProgress) return;

            MyCardsGrid.Visibility = Visibility.Visible;
            MainLobbyGrid.Visibility = Visibility.Hidden;
        }

        private void CardsExitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyCardsGrid.Visibility = Visibility.Hidden;
            MainLobbyGrid.Visibility = Visibility.Visible;
        }

        private void MainLobbyBackBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (findBtn.InProgress) return;

            App.ForceClosing = false;
            App.loginScreen.Show();
            Close();
        }            
    }
}

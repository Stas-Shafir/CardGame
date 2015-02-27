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

        CardPlace selectedCardPlace;

        int curr_page = 1;

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

            App.ProxyMutex.WaitOne();
            try
            {
                App.charInfo = ServiceProxy.Proxy.EnterWorld(App.UserName);
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

            NickNameLevel.Text = App.charInfo.nickname + ", " + App.charInfo.heroname + " " + App.charInfo.character_level + "-го уровня";
            Exp.Text = "Опыт: " + App.charInfo.exp;
            Games.Text = "Кол-во Игр: " + App.charInfo.games;
            Wins.Text = "Кол-во Побед: " + App.charInfo.wins;
            Rating.Text = "Очки: " + App.charInfo.score;

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

                App.ProxyMutex.WaitOne();
                try
                {
                    App.charInfo = ServiceProxy.Proxy.EnterWorld(App.UserName);
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

                
                App.NickName = App.charInfo.nickname;

                NickNameLevel.Text = App.charInfo.nickname + ", " + App.charInfo.heroname + " " + App.charInfo.character_level + "-го уровня";
                Exp.Text = "Опыт: " + App.charInfo.exp;
                Games.Text = "Кол-во Игр: " + App.charInfo.games;
                Wins.Text = "Кол-во Побед: " + App.charInfo.wins;
                Rating.Text = "Очки: " + App.charInfo.score;

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
            MainLobbyBackBtn.Enabled = true;
            AllCardsBtn.Enabled = true;
            App.InGame = false;
            Show();
            UpdateInfo();

        }
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

                        Thread.Sleep(500);
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
                MainLobbyBackBtn.Enabled = true;
                AllCardsBtn.Enabled = true;
                MainLobbyBackBtn.ToolTip = null;
                AllCardsBtn.ToolTip = null;
                App.InGame = false;
                return;
            }

            findBtn.Enabled = false;
            MainLobbyBackBtn.Enabled = false;
            AllCardsBtn.Enabled = false;
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
                    cp.selected = false;
                    Thread fillMyCardGridThread = new Thread(GetAllCard) { IsBackground = true };
                    fillMyCardGridThread.Start();                   
                }

                return;

            }

            DialogWin dw = new DialogWin(this, "Все боевые слоты уже заняты\nЧтобы переместить туда эту карту необходимо освободить один...",
                MessageBoxButton.OK);
            App.WindowList.Add(dw);
            dw.Show();

        }

        private void SlotCardPlace_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;            

                int oslot = cp.ThisCard.slot;
                int nslot = -1;

                bool isError = false;

                bool res = false;

                App.ProxyMutex.WaitOne();
                try
                {
                    nslot = ServiceProxy.Proxy.GetFreeSlotNumberAllCards(App.UserName);
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
                    cp.selected = false;
                    Thread fillMyCardGridThread = new Thread(GetAllCard) { IsBackground = true };
                    fillMyCardGridThread.Start();
                }

                return;

        }

        public void GetAllCard()
        {
            bool isError = false;
            List<Card> allCards = null;

            App.ProxyMutex.WaitOne();
            try
            {
                allCards = ServiceProxy.Proxy.GetAllCard(App.UserName, curr_page);
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
                    //clear 
                    foreach (CardPlace item in AllCardsGrid.Children)
                    {
                        item.ContainsCard = false;
                    }
                    foreach (CardPlace item in SlotGrid.Children)
                    {
                        item.ContainsCard = false;
                    }

                    //fill

                    foreach (var item in allCards)
                    {
                        CardPlace cp;
                        if (item.slot >= 10)
                        {
                            int index = curr_page == 1 ? item.slot - 10 : item.slot - ((curr_page - 1) * 24) - 10;
                            cp = AllCardsGrid.Children[index] as CardPlace;
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
                Thread fillMyCardGridThread = new Thread(GetAllCard) { IsBackground = true };
                fillMyCardGridThread.Start();
            }
        }

        private void AllCardsBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (findBtn.InProgress) return;

            MyCardsGrid.Visibility = Visibility.Visible;
            MainLobbyGrid.Visibility = Visibility.Hidden;

            CardsScore.Text = "Очки: " + App.charInfo.score;
        }

        private void CardsExitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MyCardsGrid.Visibility = Visibility.Hidden;
            MainLobbyGrid.Visibility = Visibility.Visible;
        }

        private void MainLobbyBackBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //if (findBtn.InProgress) return;

            App.ForceClosing = false;
            //App.isConnected = false;
            App.loginScreen.Show();

            Window_Closing(this, null);
            Window_Closed(this, null);
            Hide();
        }

        private void CardPlace_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;
            if (selectedCardPlace != null && selectedCardPlace != cp) selectedCardPlace.selected = false;           
            selectedCardPlace = cp;
        }

        //paginator --
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (curr_page > 1) curr_page--;
            currPageLabel.Content = curr_page;

            if (selectedCardPlace != null) selectedCardPlace.selected = false;

            if (curr_page >= 10) currPageLabel.Margin = new Thickness(5, 6.5, 50, 0);
            else currPageLabel.Margin = new Thickness(0,6.5,55,0);

            new Action(delegate
            {
                GetAllCard();
            }).BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar) { }), null);
        }

        //paginator++
        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            curr_page++;
            currPageLabel.Content = curr_page;

            if (selectedCardPlace!= null) selectedCardPlace.selected = false;

            if (curr_page >= 10) currPageLabel.Margin = new Thickness(0, 6.5, 50, 0);
            else currPageLabel.Margin = new Thickness(0, 6.5, 55, 0);

            new Action(delegate
            {
                GetAllCard();
            }).BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar) { }), null);
        }

        private void CardsShopBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DialogWin dw = new DialogWin(this, "Внимание!\nПокупка карты будет стоить 1000 очков\nЖелаете продолжить?",
                        MessageBoxButton.YesNo);

            App.WindowList.Add(dw);
            if (dw.ShowDialog() == true)
            {
                new Action(delegate
                {
                    Card card = null;
                    bool isError = false;

                    App.ProxyMutex.WaitOne();
                    try
                    {
                        card = ServiceProxy.Proxy.BuyCard(App.UserName);
                        App.charInfo = ServiceProxy.Proxy.EnterWorld(App.UserName);
                        GetAllCard();

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

                    if (card == null)
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            DialogWin dw2 = new DialogWin(this, "Недостаточно средств.\nДля покупки необходимо не менее 1000 очков",
                                MessageBoxButton.OK);
                            App.WindowList.Add(dw2);
                            dw2.Show();
                        }));
                    }
                    else
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                        {
                            Rating.Text = "Очки: " + App.charInfo.score;
                            CardsScore.Text = "Очки: " + App.charInfo.score;
                            NewCardWindow ncw = new NewCardWindow(card, this);
                            App.WindowList.Add(ncw);
                            ncw.ShowDialog();
                        }));
                    }
                }).BeginInvoke(new AsyncCallback(delegate(IAsyncResult ar) { }), null);
            }
        }            
    }
}

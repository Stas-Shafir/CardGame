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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using CardGameServer;
using System.Windows.Threading;
using System.Threading;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CardPlace mySelectedCardPlace;
        CardPlace enemySelectedCardPlace;

        int lasthitCard = -1;

        bool known = false;

        public Game game;

        Dictionary<int, CardPlace> myCardPlases = new Dictionary<int, CardPlace>();
        Dictionary<int, CardPlace> enemyCardPlases = new Dictionary<int, CardPlace>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myCardPlace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;

            if (mySelectedCardPlace != null && cp != mySelectedCardPlace) 
                mySelectedCardPlace.selected = false;

            mySelectedCardPlace = cp;

            foreach (var item in enemyCardPlases.Values)
            {
                if (item.ContainsCard && item.ThisCard.Enabled)
                item.IsEnabled = true;
            }
        }

        private void enemyCardPlace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                CardPlace cp = sender as CardPlace;

                if (enemySelectedCardPlace != null && enemySelectedCardPlace != cp)
                    enemySelectedCardPlace.selected = false;

                enemySelectedCardPlace = cp;

                foreach (var item in enemyCardPlases.Values)
                {
                    item.IsEnabled = false;
                }

                foreach (var item in myCardPlases.Values)
                {
                    item.IsEnabled = false;
                }

                //attack
                bool isError = false;
                int dmg = -1;
                App.ProxyMutex.WaitOne();
                try
                {
                    dmg = ServiceProxy.Proxy.DoAttack(App.NickName, mySelectedCardPlace.ThisCard.slot,
                        enemySelectedCardPlace.ThisCard.slot);
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

                //if success
                if (dmg != -1)
                {
                    enemySelectedCardPlace.AnimateDmg(dmg.ToString());
                    mySelectedCardPlace.AnimateTurn();
                }

                enemySelectedCardPlace.selected = mySelectedCardPlace.selected = false;

                foreach (var item in myCardPlases.Values)
                {
                    if (item.ContainsCard && item.ThisCard.Enabled)
                        item.IsEnabled = true;
                }
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


        public void DoGame()
        {
            try
            {
                while (true)
                {
                    Thread.Sleep(500);

                    bool isError = false;

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
                        if (game.gameState == 2 || game.gameState == 3)
                        {
                            foreach (var item in game.firstGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.fGamer.nick == App.NickName)
                                    {
                                        if (myCardPlases[item.slot].ThisCard != null &&
                                            myCardPlases[item.slot].ThisCard.hp > item.hp && lasthitCard != game.lastHitCardSlot)
                                        {
                                            enemyCardPlases[game.lastHitCardSlot].AnimateTurn(true);
                                            lasthitCard = game.lastHitCardSlot;
                                        }

                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].Enabled = item.Enabled;
                                    }
                                    else
                                        enemyCardPlases[item.slot].ThisCard = item;
                                }));
                            }

                            foreach (var item in game.twoGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.fGamer.nick != App.NickName)
                                    {
                                        if (myCardPlases[item.slot].ThisCard != null &&
                                            myCardPlases[item.slot].ThisCard.hp > item.hp && lasthitCard != game.lastHitCardSlot)
                                        {
                                            enemyCardPlases[game.lastHitCardSlot].AnimateTurn(true);
                                            lasthitCard = game.lastHitCardSlot;
                                        }

                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].Enabled = item.Enabled;
                                    }
                                    else
                                        enemyCardPlases[item.slot].ThisCard = item;
                                }));
                            }

                            this.Dispatcher.Invoke(new Action(delegate
                            {
                                if (game.currUsr == App.NickName)
                                {
                                    menuTop.btnText = "Ваш\nХод";

                                    boardGrid.IsEnabled = true;

                                    foreach (var item in myCardPlases.Values)
                                    {
                                        if (item.ContainsCard && item.ThisCard.Enabled)
                                            item.Enabled = true;
                                    }
                                }
                                else
                                {
                                    menuTop.btnText = "Ход\nсоперника";

                                   /* if (!known)
                                    {
                                        lasthitCard = -1;
                                        known = true;
                                    }*/

                                    boardGrid.IsEnabled = false;

                                    foreach (var item in myCardPlases.Values)
                                    {
                                        item.Enabled = false;
                                    }
                                }
                            }));
                        }
                        else if (game.gameState == 4)
                        {
                            foreach (var item in game.firstGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.fGamer.nick == App.NickName)
                                    {
                                        if (myCardPlases[item.slot].ThisCard != null &&
                                            myCardPlases[item.slot].ThisCard.hp > item.hp && lasthitCard != game.lastHitCardSlot)
                                        {
                                            enemyCardPlases[game.lastHitCardSlot].AnimateTurn(true);
                                            lasthitCard = game.lastHitCardSlot;
                                        }

                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].Enabled = item.Enabled;
                                    }
                                    else
                                        enemyCardPlases[item.slot].ThisCard = item;
                                }));
                            }

                            foreach (var item in game.twoGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.fGamer.nick != App.NickName)
                                    {
                                        if (myCardPlases[item.slot].ThisCard != null &&
                                            myCardPlases[item.slot].ThisCard.hp > item.hp && lasthitCard != game.lastHitCardSlot)
                                        {
                                            enemyCardPlases[game.lastHitCardSlot].AnimateTurn(true);
                                            lasthitCard = game.lastHitCardSlot;
                                        }

                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].Enabled = item.Enabled;
                                    }
                                    else
                                        enemyCardPlases[item.slot].ThisCard = item;
                                }));
                            }

                            this.Dispatcher.Invoke(new Action(delegate
                            {
                                App.InGame = false;
                                string text = "";

                                GameResultWindow grw = null;

                                if (game.currUsr == App.NickName)
                                {
                                    grw = new GameResultWindow("Победа!", game.WinGamerReward.NewLevel, game.WinGamerReward.Exp,
                                        game.WinGamerReward.Score, game.WinGamerReward.NewCard);
                                }
                                else
                                {
                                    grw = new GameResultWindow("Поражение!", game.LooseGamerReward.NewLevel, game.LooseGamerReward.Exp,
                                        game.LooseGamerReward.Score, game.LooseGamerReward.NewCard);
                                }

                                App.WindowList.Add(grw.Name, grw);

                                grw.ShowDialog();

                                App.WindowList["LobbyWnd"].Show();
                                (App.WindowList["LobbyWnd"] as LobbyScreen).OnGameEnd();
                                Hide();
                                //Close();
                            }));

                            return;
                        }
                        else if (game.gameState == 5)
                        {
                            this.Dispatcher.Invoke(new Action(delegate
                            {
                                App.InGame = false;
                                GameResultWindow grw = new GameResultWindow("Победа!", game.WinGamerReward.NewLevel, game.WinGamerReward.Exp,
                                        game.WinGamerReward.Score, game.WinGamerReward.NewCard);

                                App.WindowList.Add(grw.Name, grw);

                                grw.ShowDialog();

                                App.WindowList["LobbyWnd"].Show();
                                (App.WindowList["LobbyWnd"] as LobbyScreen).OnGameEnd();
                                Hide();
                                //Close();
                            }));

                            return;
                        }
                    }
                    else return;
                }
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

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (UIElement item in boardGrid.Children)
                {
                    CardPlace cp = item as CardPlace;

                    if (cp != null)
                    {
                        if (cp.Name.Contains("MyPlace"))
                            myCardPlases.Add(Int32.Parse(cp.Tag.ToString()), cp);
                        else if (cp.Name.Contains("EnemyPlace"))
                            enemyCardPlases.Add(Int32.Parse(cp.Tag.ToString()), cp);
                    }
                }

                OnWindowShow();



                /* this.Dispatcher.Invoke(new Action(() =>
                         Owner.Hide()
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
                    game = null;
                    App.OnConnectionError();
                    return;
                }
            }).Invoke();

            if (game != null)
            {
                foreach (var item in myCardPlases.Values)
                {
                    item.inGame = true;
                }

                foreach (var item in enemyCardPlases.Values)
                {
                    item.inGame = false;
                }


                if (App.NickName == game.fGamer.nick)
                {
                    menuTop.firstUserNickname = App.NickName;
                    menuTop.twoUserNickname = game.tGamer.nick;
                }
                else
                {
                    menuTop.firstUserNickname = App.NickName;
                    menuTop.twoUserNickname = game.fGamer.nick;
                }

                Thread gameThread = new Thread(DoGame) { IsBackground = true };
                gameThread.Start();
            }
            else throw new Exception("game is null");
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

            if (App.ForceClosing)
            {
                if (App.isConnected && ServiceProxy.Proxy != null)
                {
                    App.ProxyMutex.WaitOne();
                    try
                    {
                        ServiceProxy.Proxy.Logout(App.UserName);
                    }
                    catch {}
                    App.ProxyMutex.ReleaseMutex();
                }

                App.isConnected = false;
                Application.Current.Shutdown();
            }
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

        private void CardPlace_MouseEnter(object sender, MouseEventArgs e)
        {
           /* CardPlace ccp = sender as CardPlace;

            if (!ccp.ContainsCard) return;

            if (ccp.IsMineCard)
            {
                ccp.ToolTip = "Характеристики:\nАтака: " + ccp.ThisCard.dmg + "\nЗащита: " + ccp.ThisCard.def;
            }*/


        }


        private void EnemyCardPlace_MouseEnter(object sender, MouseEventArgs e)
        {
            /*CardPlace ccp = sender as CardPlace;

            if (!ccp.ContainsCard) return;

            if (!ccp.IsMineCard)
            {
                ccp.ToolTip = "Характеристики:\nАтака: " + ccp.ThisCard.dmg + "\nЗащита: " + ccp.ThisCard.def;
            }*/
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                InGameMenuEscWindow igmew = new InGameMenuEscWindow(this);
                App.WindowList.Add(igmew.Name, igmew);
                igmew.Show();
            }
        }

        private void MainWnd_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            /*if (Visibility == Visibility.Visible)
            {
                if (myCardPlases.Count() != 0)
                {
                    mySelectedCardPlace = null;
                    enemySelectedCardPlace = null;
                    game = null;

                    myCardPlases = new Dictionary<int, CardPlace>();
                    enemyCardPlases = new Dictionary<int, CardPlace>();
                   // Window_Loaded_1(this, null);
                }
            }*/
            if (Visibility == Visibility.Hidden)
            {
                menuTop.btnText = "";
                boardGrid.IsEnabled = false;
                menuTop.firstUserNickname = "";
                menuTop.twoUserNickname = "";
                mySelectedCardPlace = null;
                enemySelectedCardPlace = null;
                game = null;

                foreach (var item in myCardPlases.Values)
                {
                    item.inGame = false;
                    item.ContainsCard = false;
                    item.ThisCard = null;
                }

                foreach (var item in enemyCardPlases.Values)
                {
                    item.inGame = false;
                    item.ContainsCard = false;
                    item.ThisCard = null;
                }
            }
        }

    }
}

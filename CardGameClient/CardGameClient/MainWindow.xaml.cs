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
        Game game;

        Dictionary<int, CardPlace> myCardPlases = new Dictionary<int, CardPlace>();
        Dictionary<int, CardPlace> enemyCardPlases = new Dictionary<int, CardPlace>();

        public MainWindow(Window own)
        {
            InitializeComponent();
            Owner = own;           
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
                int dmg = ServiceProxy.Proxy.DoAttack(App.NickName, mySelectedCardPlace.ThisCard.slot,
                    enemySelectedCardPlace.ThisCard.slot);

                //if success
                if (dmg != -1) enemySelectedCardPlace.AnimateDmg(dmg.ToString());

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
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
                    App.isConnected = false;
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
                    game = ServiceProxy.Proxy.getGame(App.NickName);

                    if (game != null)
                    {  
                        if (game.gameState == 2 || game.gameState == 3)
                        {
                            foreach (var item in game.firstGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.Gamers[0] == App.NickName)
                                    {
                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].IsEnabled = item.Enabled;
                                    }
                                    else
                                        enemyCardPlases[item.slot].ThisCard = item;
                                }));
                            }

                            foreach (var item in game.twoGamerCards)
                            {
                                this.Dispatcher.Invoke(new Action(delegate
                                {
                                    if (game.Gamers[0] != App.NickName)
                                    {
                                        myCardPlases[item.slot].ThisCard = item;
                                        myCardPlases[item.slot].IsEnabled = item.Enabled;
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

                                    foreach (var item in myCardPlases.Values)
                                    {
                                        if (item.ContainsCard && item.ThisCard.Enabled)
                                            item.IsEnabled = true;
                                    }
                                }
                                else
                                {
                                    menuTop.btnText = "Ход\nсоперника";

                                    foreach (var item in myCardPlases.Values)
                                    {
                                        item.IsEnabled = false;
                                    }
                                }
                            }));
                        }
                        else if (game.gameState == 4)
                        {
                            this.Dispatcher.Invoke(new Action(delegate
                            {
                                App.InGame = false;
                                string text = "Награда: \n";

                                if (game.currUsr == App.NickName){
                                    if (game.WinGamerReward.NewLevel)
                                    {
                                        text += "Новый уровень!\n";
                                    }
                                    text += "Опыт: " + game.WinGamerReward.Exp;
                                    if (game.WinGamerReward.NewCard != null )
                                    {
                                        text += "Новая карта: " + game.WinGamerReward.NewCard.card_name;
                                    }
                                }
                                else 
                                {
                                    if (game.LooseGamerReward.NewLevel)
                                    {
                                        text += "Новый уровень!\n";
                                    }
                                    text += "Опыт: " + game.LooseGamerReward.Exp;
                                }


                                if (game.currUsr == App.NickName)
                                    MessageBox.Show(text, "Победа");
                                else MessageBox.Show(text, "Поражение");

                                App.ForceClosing = false;
                                Close();
                            }));

                            return;
                        }
                        else if (game.gameState == 5)
                        {
                            this.Dispatcher.Invoke(new Action(delegate
                            {
                                App.InGame = false;
                                MessageBox.Show("Победа за вами", "Противник отключился");

                                App.ForceClosing = false;
                                Close();
                            }));

                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
                    App.isConnected = false;
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

                game = ServiceProxy.Proxy.getGame(App.NickName);

                if (App.NickName == game.Gamers[0])
                {
                    menuTop.firstUserNickname = App.NickName;
                    menuTop.twoUserNickname = game.Gamers[1];
                }
                else
                {
                    menuTop.firstUserNickname = App.NickName;
                    menuTop.twoUserNickname = game.Gamers[0];
                }                

                Thread gameThread = new Thread(DoGame) { IsBackground = true};
                gameThread.Start();



                /* this.Dispatcher.Invoke(new Action(() =>
                         Owner.Hide()
                     ), DispatcherPriority.ContextIdle, null);*/
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
                    App.isConnected = false;
                    Application.Current.Shutdown();
                }));
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Owner.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.isConnected && ServiceProxy.Proxy != null)
            {
                ServiceProxy.Proxy.leaveGame(App.NickName);
            }

            if (App.ForceClosing)
            {
                if (App.isConnected && ServiceProxy.Proxy != null)
                {
                    ServiceProxy.Proxy.Logout(App.UserName);
                }

                App.isConnected = false;
                Application.Current.Shutdown();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.ForceClosing = true;
        }

        private void CardPlace_MouseEnter(object sender, MouseEventArgs e)
        {
            CardPlace ccp = sender as CardPlace;

            if (!ccp.ContainsCard) return;

            if (ccp.IsMineCard) 
                ccp.ToolTip = "Характеристики:\nАтака: " + ccp.ThisCard.dmg + "\nЗащита: " + ccp.ThisCard.def;
        }


        private void EnemyCardPlace_MouseEnter(object sender, MouseEventArgs e)
        {
            CardPlace ccp = sender as CardPlace;

            if (!ccp.ContainsCard) return;

            if (!ccp.IsMineCard)                
                ccp.ToolTip = "Характеристики:\nАтака: " + ccp.ThisCard.dmg + "\nЗащита: " + ccp.ThisCard.def +
                    "\nВы нанесёте " + (mySelectedCardPlace.ThisCard.dmg - (ccp.ThisCard.def / 2)) + " урона.";
        }
    }
}

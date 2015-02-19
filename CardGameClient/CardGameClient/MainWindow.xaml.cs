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

        private void myCardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;

            if (mySelectedCardPlace != null && cp != mySelectedCardPlace) 
                mySelectedCardPlace.selected = false;

            mySelectedCardPlace = cp;


            foreach (var item in enemyCardPlases.Values)
            {
                item.IsEnabled = true;
            }
        }

        private void enemyCardPlace_MouseUp(object sender, MouseButtonEventArgs e)
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
            enemySelectedCardPlace.AnimateDmg("55");
            //if success
            //

            enemySelectedCardPlace.selected = mySelectedCardPlace.selected = false;

            foreach (var item in myCardPlases.Values)
            {
                item.IsEnabled = true;
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


                foreach (var item in game.firstGamerCards)
                {
                    if (game.currUsr == App.NickName)
                        myCardPlases[item.slot].ThisCard = item;
                    else
                        enemyCardPlases[item.slot].ThisCard = item;
                }

                foreach (var item in game.twoGamerCards)
                {
                    if (game.currUsr != App.NickName)
                        myCardPlases[item.slot].ThisCard = item;
                    else
                        enemyCardPlases[item.slot].ThisCard = item;
                }

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

                if (game.currUsr == App.NickName)
                    menuTop.btnText = "Ваш\nХод";
                else menuTop.btnText = "Ход\nсоперника";



                /* this.Dispatcher.Invoke(new Action(() =>
                         Owner.Hide()
                     ), DispatcherPriority.ContextIdle, null);*/
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(delegate
                {
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
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
            if (App.ForceClosing)
                Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.ForceClosing = true;
        }
    }
}

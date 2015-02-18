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

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for LobbyScreen.xaml
    /// </summary>
    public partial class LobbyScreen : Window
    {
        bool inFindProgress = false;

        public LobbyScreen(Window ownwin)
        {
            InitializeComponent();
            this.Owner = ownwin;
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

        private void exitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.ForceClosing = false;
            App.loginScreen.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CharInfo ch = ServiceProxy.Proxy.EnterWorld(App.UserName);

                App.NickName = ch.nickname;

                NickNameLevel.Text = ch.nickname + ", " + ch.heroname + " " + ch.character_level + "-го уровня";
                Exp.Text = "Опыт: " + ch.exp;
                Games.Text = "Кол-во Игр: " + ch.games;
                Wins.Text = "Кол-во Побед: " + ch.wins;
                Rating.Text = "Ваш рейтинг: " + ch.rating;

                Thickness mrg = new Thickness(5, 5, 0, 5);


                List<CharInfo> RankingList = ServiceProxy.Proxy.getRanking();

                for (int i = 0; i < RankingList.Count; i++)
                {
                    CharInfo currCharInf = RankingList[i];

                    Label tx = new Label()
                    {
                        Content = (i+1).ToString(),
                        Foreground = Brushes.Wheat,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    ratingGrid.Children.Add(tx);
                    Grid.SetRow(tx, i+1);
                    Grid.SetColumn(tx, 0);



                    tx = new Label()
                    {
                        Content = currCharInf.nickname,
                        Foreground = Brushes.Wheat,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    ratingGrid.Children.Add(tx);
                    Grid.SetRow(tx, i+1);
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
                    Grid.SetRow(tx, i+1);
                    Grid.SetColumn(tx, 2);


                    tx = new Label()
                    {
                        Content = currCharInf.games.ToString(),
                        Foreground = Brushes.Wheat,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center

                    };
                    ratingGrid.Children.Add(tx);
                    Grid.SetRow(tx, i+1);
                    Grid.SetColumn(tx, 3);


                    tx = new Label()
                    {
                        Content = currCharInf.wins.ToString(),
                        Foreground = Brushes.Wheat,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    ratingGrid.Children.Add(tx);
                    Grid.SetRow(tx, i+1);
                    Grid.SetColumn(tx, 4);
                }

                

                this.Dispatcher.Invoke(new Action(delegate 
                {
                    /*if ((Owner as LoginScreen) != null)
                        Owner.Hide();
                    else
                    {
                        App.ForceClosing = false;
                        Owner.Close(); 
                    }*/

                    //TODO: Closing CreateCharacterScreen need...
                    Owner.Hide();
                }), DispatcherPriority.ContextIdle, null);
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(() =>
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!")
                ));

                Application.Current.Shutdown();
            }
        }

        private void FindGame()
        {
            try
            {
                //imitation of the search process)))
                Thread.Sleep(2000);

                Game game = ServiceProxy.Proxy.findGame(App.NickName);
                if (game == null) throw new Exception("Некорректные данные или была обнаружена попытка взлома.\n"
                 + "Действие было записано...");

                Thread gameThread = new Thread(getGame) { IsBackground = true };
                gameThread.Start();

            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action(() =>
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!")
                ));
                Application.Current.Shutdown();
            }
        }

        private void findBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            inFindProgress = !inFindProgress;

            if (!inFindProgress) return;

            //TODO: cancel search???

            Thread findGameThread = new Thread(FindGame) { IsBackground = true };
            findGameThread.Start();
        }

        private void getGame()
        {
            while (true)
            {
                Game game = ServiceProxy.Proxy.findGame(App.NickName);
                if (game != null)
                {

                    if (game.gameState == 2 || game.gameState == 3)
                    {
                        //TODO: Game Window show and play...
                        break;
                    }
                }
                
            }
        }
    }
}

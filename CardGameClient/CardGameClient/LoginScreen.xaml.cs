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

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        BitmapImage myCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_my_border.png"));
        BitmapImage enemyCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_enemy_border.png"));


        public LoginScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btn_login_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void btn_login_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_login_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}

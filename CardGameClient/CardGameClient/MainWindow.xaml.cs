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

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CardPlace mySelectedCardPlace;
        CardPlace enemySelectedCardPlace;

        public MainWindow()
        {
            InitializeComponent();


            foreach (var item in Directory.GetFiles("Images/Numeric/", "*.png", SearchOption.AllDirectories))
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(item, UriKind.Relative);
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();


                App.digitImages.Add(Int32.Parse(System.IO.Path.GetFileNameWithoutExtension(item)), img);
            }
        }

        private void myCardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (mySelectedCardPlace != null) mySelectedCardPlace.selected = false;
            CardPlace cp = sender as CardPlace;
            //CardIndex = cp.CardInfo.id;
            mySelectedCardPlace = cp;
        }

        private void enemyCardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (enemySelectedCardPlace != null) enemySelectedCardPlace.selected = false;
            CardPlace cp = sender as CardPlace;
            //CardIndex = cp.CardInfo.id;
            enemySelectedCardPlace = cp;
        }
    }
}

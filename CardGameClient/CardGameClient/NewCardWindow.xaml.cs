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
using CardGameServer;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for NewCardWindow.xaml
    /// </summary>
    public partial class NewCardWindow : Window
    {
        public NewCardWindow(Card card, Window own)
        {
            InitializeComponent();
            Owner = own;
            NewCardPlace.ThisCard = card;
            CardNameLabel.Content = card.card_name;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.WindowList.Remove(this);
            Close();
        }
    }
}

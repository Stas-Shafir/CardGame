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
using CardGameServer;
using System.Windows.Media.Animation;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for CardPlace.xaml
    /// </summary>
    public partial class CardPlace : UserControl
    {

        private bool containsCard = false;
        private bool isMineCard;

        private bool isSelected = false;

        public string Health
        {
            get
            {
                return HpDig.DigitValue;
            }
            set
            {
                HpDig.DigitValue = value;
            }
        }

        public bool selected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;

                if (!isSelected)
                {
                    borderGrid.Visibility = Visibility.Hidden;
                    animation.BeginTime = null;
                    borderGrid.BeginAnimation(MarginProperty, animation);
                }
            }
        }

        ThicknessAnimation animation = new ThicknessAnimation(new Thickness(-7), new Thickness(-5), TimeSpan.FromMilliseconds(600));

        public Card CardInfo {get; set;}
        
        ImageBrush myCardBg = new ImageBrush(new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_my_bg.png" )));
        ImageBrush enemyCardBg = new ImageBrush(new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_enemy_bg.png")));

        BitmapImage myCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_my_border.png"));
        BitmapImage enemyCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_enemy_border.png"));

        public ImageSource Card
        {
            get
            {
                return Portrait.Source;
            }
            set
            {
                Portrait.Source = value;
                ContainsCard = true;
                borderImg.Source = isMineCard ? myCardBorder : enemyCardBorder;
            }
        }

        public bool IsMineCard
        {
            get
            {
                return isMineCard;
            }
            set
            {
                GridMain.Background = (isMineCard = value) ? myCardBg : enemyCardBg;
                borderImg.Source = isMineCard ? myCardBorder : enemyCardBorder;
            }
        }

        public bool ContainsCard
        {
            get
            {
                return containsCard;
            }
            set
            {
                containsCard = value;
                CardCrid.Visibility = containsCard ? Visibility.Visible : Visibility.Hidden;
            }
        }

        public CardPlace()
        {
            InitializeComponent();
            GridMain.Background = IsMineCard ? myCardBg : enemyCardBg;
            animation.RepeatBehavior = RepeatBehavior.Forever;
            animation.AutoReverse = true;
        }


        public void setCard(BitmapImage img)
        {
            Card = img;
            ContainsCard = true;
        }

        public void removeCard()
        {
            Card = null;
            ContainsCard = false;
        }


        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ContainsCard && !selected)
            {
                borderGrid.Visibility = Visibility.Visible;
                animation.BeginTime = TimeSpan.FromMilliseconds(0);
                animation.Duration = TimeSpan.FromMilliseconds(600);
                animation.From = new Thickness(-7);
                animation.To = new Thickness(-5);
                borderGrid.BeginAnimation(MarginProperty, animation);
            }
            
        }

        private void GridMain_MouseLeave(object sender, MouseEventArgs e)
        {
            if (ContainsCard && !selected)
            {
                borderGrid.Visibility = Visibility.Hidden;
                animation.BeginTime = null;
                borderGrid.BeginAnimation(MarginProperty, animation);
            }
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContainsCard)
            {
                selected = true;
                animation.Duration = TimeSpan.FromMilliseconds(200);
                animation.From = new Thickness(-6);
                animation.To = new Thickness(-5);
                borderGrid.BeginAnimation(MarginProperty, animation);
            }
        }
    }
}

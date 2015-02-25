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

        Card thisCard;

        public Card ThisCard
        {
            get 
            {
                return thisCard; 
            }
            set 
            {
                if (thisCard != null && thisCard.hp <= 0) return;


                    if (thisCard != null && value.hp < thisCard.hp && isMineCard)
                        AnimateDmg((thisCard.hp - value.hp).ToString());

                    thisCard = value;
                    CardImage = App.cardImages[thisCard.id];
                    if (thisCard.hp <= 0) CardDeath();
                    Health = thisCard.hp.ToString();
            }
        }

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

        ImageBrush myCardBg = new ImageBrush(new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_my_bg.png" )));
        ImageBrush enemyCardBg = new ImageBrush(new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_enemy_bg.png")));

        BitmapImage myCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_my_border.png"));
        BitmapImage enemyCardBorder = new BitmapImage(
            new Uri("pack://application:,,,/CardGameClient;component/Images/cardmin_enemy_border.png"));

        public ImageSource CardImage
        {
            get
            {
                return Portrait.Source;
            }
            set
            {
                Portrait.Source = value;
                if (value != null)
                {
                    ContainsCard = true;
                    borderImg.Source = isMineCard ? myCardBorder : enemyCardBorder;
                }
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
            CardImage = img;
            ContainsCard = true;
        }

        public void CardDeath()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.From = 1;
            da.To = 0;
            da.Duration = TimeSpan.FromMilliseconds(500);
            da.FillBehavior = FillBehavior.Stop;
            da.Completed += delegate(object sender, EventArgs e)
            {
                CardImage = null;
                ContainsCard = false;
            };
            BeginAnimation(OpacityProperty, da);            
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

        public void AnimateDmg(string dmg)
        {
            dmgLabel.Content = dmg;

            dmgLabel.Opacity = 1;

            ThicknessAnimation th = new ThicknessAnimation();
            th.From = dmgLabel.Margin;
            th.FillBehavior = FillBehavior.Stop;
            th.To = new Thickness(dmgLabel.Margin.Left, dmgLabel.Margin.Top - 70, dmgLabel.Margin.Right, dmgLabel.Margin.Bottom);
            th.Duration = TimeSpan.FromMilliseconds(500);
            th.Completed += new EventHandler(th_Completed);
            //th.BeginTime = TimeSpan.FromMilliseconds(200);
            dmgLabel.BeginAnimation(MarginProperty, th);
        }

        void th_Completed(object sender, EventArgs e)
        {
            dmgLabel.Opacity = 0;
            dmgLabel.Content = "";

            dmgLabel.Margin = new Thickness(0, 6, 6, 0);
        }
    }
}

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

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for DialogWin.xaml
    /// </summary>
    public partial class DialogWin : Window
    {
        public DialogWin(Window own, string txt, MessageBoxButton btns)
        {
            InitializeComponent();
            Owner = own;
            TextInfo.Text = txt;

            if (btns == MessageBoxButton.YesNo)
                AcceptBtn.Visibility = CancelBtn.Visibility = Visibility.Visible;
            else if (btns == MessageBoxButton.OK)
                AcceptBtnOnly.Visibility = Visibility.Visible;
        }

        //accept
        private void AcceptBtnOnly_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (AcceptBtnOnly.Visibility != Visibility.Visible)
                DialogResult = true;

            Close();
        }

        //cancel
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (AcceptBtnOnly.Visibility != Visibility.Visible)
                DialogResult = false;

            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.WindowList.Remove(this.Name);
        }
    }
}

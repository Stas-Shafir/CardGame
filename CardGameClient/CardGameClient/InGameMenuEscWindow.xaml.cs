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
    /// Interaction logic for InGameMenuEscWindow.xaml
    /// </summary>
    public partial class InGameMenuEscWindow : Window
    {
        public InGameMenuEscWindow(Window own)
        {
            InitializeComponent();
            Owner = own;
        }

        private void CancelBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void LeaveBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.ForceClosing = false;
            App.WindowList.Remove(this);
            Owner.Close();
            Close();
        }

        private void ExitBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            App.ForceClosing = true;
            Owner.Close();
            App.WindowList.Remove(this);
            Close();
        }
    }
}

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
using System.IO;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for CharacterCreateScreen.xaml
    /// </summary>
    public partial class CharacterCreateScreen : Window
    {
        private LoginScreen LoginWindow;
        int CardIndex = -1;
        CardPlace selectedCardPlace;

        public CharacterCreateScreen(Window ownwin)
        {
            InitializeComponent();
            this.Owner = ownwin;
            LoginWindow = Owner as LoginScreen;
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
            LoginWindow.Show();
            Close();
        }

        private void createCharBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string charName = characterNameTextBox.Text;

            if (charName == "" || sqlInjection.Words.Any(word => charName.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                errorText.Content = "Поле заполнено некорректно";
                return;
            }

            if (charName.Length <= 3 || charName.Length > 16)
            {
                errorText.Content = "Имя персонажа: Введите от 4 до 16 символов";
                return;
            }

            if (CardIndex == -1)
            {
                errorText.Content = "Вы забыли выбрать героя...";
                return;
            }

            try
            {
                App.NickName = charName;
                if (ServiceProxy.Proxy.createCharacter(App.UserName, App.NickName, CardIndex))
                {
                    errorText.Content = "Персонаж успешно создан...";
                }

                else
                {
                    errorText.Content = "Ошибка при создании персонажа. Персонаж с таким именем уже существует...";
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Card> templates = ServiceProxy.Proxy.getHeroesTemplateAvailableList();
            CardPlace cp;

            for (int i = 0; i < templates.Count; i++)
            {
                cp = gridHeroes.Children[i] as CardPlace;
                cp.Card = App.cardImages[templates[i].id];
                cp.CardInfo = templates[i];
            }
        }

        private void CardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (selectedCardPlace != null) selectedCardPlace.selected = false;
            CardPlace cp = sender as CardPlace;
            CardIndex = cp.CardInfo.id;
            selectedCardPlace = cp;
        }
    }
}

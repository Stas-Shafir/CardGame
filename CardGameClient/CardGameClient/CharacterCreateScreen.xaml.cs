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
using System.Threading;
using System.Windows.Threading;

namespace CardGameClient
{
    /// <summary>
    /// Interaction logic for CharacterCreateScreen.xaml
    /// </summary>
    public partial class CharacterCreateScreen : Window
    {
        int CardIndex = -1;
        CardPlace selectedCardPlace;

        public CharacterCreateScreen(Window ownwin)
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


        private void CreateCharacter()
        {
            try
            {                
                if (ServiceProxy.Proxy.createCharacter(App.UserName, App.NickName, CardIndex))
                {
                    this.Dispatcher.Invoke(new Action(delegate {
                        LobbyScreen ls = new LobbyScreen(this);
                        ls.Show();
                    }));
                }

                else
                {
                    this.Dispatcher.Invoke(new Action( () =>
                        errorText.Content = "Ошибка при создании персонажа. Персонаж с таким именем уже существует..." 
                    ));
                }
            }
            catch (Exception exc)
            {
                this.Dispatcher.Invoke(new Action( () =>
                    MessageBox.Show(exc.Message + "\n\n" + exc.InnerException.Message, "Критическая ошибка!")
                ));
            }
        }

        private void createCharBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            string charName = characterNameTextBox.Text;

            if (charName == "" || sqlInjection.Words.Any(word => charName.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                errorText.Content = "Поле заполнено некорректно";
                return;
            }

            if (charName.Length <= 2 || charName.Length > 16)
            {
                errorText.Content = "Ошибка: Введите от 3 до 16 символов";
                return;
            }

            if (CardIndex == -1)
            {
                errorText.Content = "Вы забыли выбрать героя...";
                return;
            }

            App.NickName = charName;

            Thread createCharacter = new Thread(CreateCharacter) { IsBackground = true };
            createCharacter.Start();            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Card> templates = ServiceProxy.Proxy.getHeroesTemplateAvailableList();
                CardPlace cp;

                for (int i = 0; i < templates.Count; i++)
                {
                    cp = gridHeroes.Children[i] as CardPlace;
                    cp.ThisCard = templates[i];
                }


               /* this.Dispatcher.Invoke(new Action(() =>
                    App.loginScreen.Hide()
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

        private void CardPlace_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CardPlace cp = sender as CardPlace;
            if (selectedCardPlace != null && selectedCardPlace != cp) selectedCardPlace.selected = false;
            CardIndex = cp.ThisCard.id;
            selectedCardPlace = cp;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            App.loginScreen.Hide();
        }
    }
}

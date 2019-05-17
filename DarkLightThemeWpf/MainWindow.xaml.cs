using DarkLightThemeWpf;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
 
namespace ThemesApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";

            for(int i = 0; i < contacts.Count;i++)
            {
                contactsListBox.Items.Add(contacts[i].Name);

            }
        }
 
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            
            Application.Current.Resources.Clear();
            
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

           List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    Name = "Саня",
                    Chat = new List<string>
                    {
                        "Саня: Привет!",
                        "Я: Привет",
                        "Саня: Одолжишь сотку до понедельника?"
                    }
                },
                new Contact { Name = "Алиса",
                Chat = new List<string>{
                    "Алиса: Привет, пошли погуляем?",
                    "Я: А может потом? А то на улице холодно",
                    "Алиса: Ладно, пойду с Саней",
                    "Я: Стоять, ладно, давай встретимся в 4"
                } },
                new Contact
                {
                    Name = "Глеб",
                    Chat = new List<string>{
                        "Я: Привет, скинешь конспект по физике?",
                        "Глеб: Да, конечно.",
                        "Глеб: 19 фотографий",
                        "Я: -_-",
                        "Я: Спасибо"
                    }
                    
                }
                


            };
        private void FindButtonClick(object sender, RoutedEventArgs e)
        {
         ;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Name.Contains(findTextBox.Text))
                {
                    contactsListBox.Items.Remove(contacts[i].Name);

                    contactsListBox.Items.Add(contacts[i].Name);
                }
                else
                {
                    contactsListBox.Items.Remove(contacts[i].Name);
                }

            }
        }

        private void ContactsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string name = contactsListBox.SelectedItem.ToString();
            int index = 0;
            for(int i = 0; i < contacts.Count;i++)
            {
                if(contacts[i].Name == name)
                {
                    index = i;
                }
                else
                {
                for (int j = 0; j < contacts[i].Chat.Count;j++)
                {
                chatListBox.Items.Remove(contacts[i].Chat[j]);

                }
                }

            }
            for (int j = 0; j < contacts[index].Chat.Count; j++)
            {
            chatListBox.Items.Add(contacts[index].Chat[j]);
            }
            }
            catch
            {

            }
        }
    }
}
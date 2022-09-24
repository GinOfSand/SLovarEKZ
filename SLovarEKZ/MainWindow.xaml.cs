using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SLovarEKZ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        static int translition_position = 0;
        static int word_position = 0;
        static Word[] wrd = new Word[1];
        static BookWord LoadedBook = new BookWord("ABC", wrd);

        public MainWindow()
        {
            InitializeComponent();
            BookWordName.Content = LoadedBook.BW_name;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void WordTranslitionSearch_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedBook != null)
            {
                
                for (int i = 0; i < LoadedBook.Word_Tr.Length; i++)
                {
                    if (LoadedBook.Word_Tr[i].Words == WordTextBox.Text)
                    {
                        WordTranslitionBox.Text = LoadedBook.Word_Tr[i].Word_translition[0];
                        word_position = i;
                    }
                    else
                    {
                        MessageBox.Show("Слово не найдено","Мимо", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Библиотека переводов не загружена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DelWord_Click(object sender, RoutedEventArgs e)
        {
            if(LoadedBook != null)
            {
                LoadedBook.DeleteWord(WordTextBox.Text);
            }
            else
            {
                MessageBox.Show("Библиотека переводов не загружена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedBook != null)
            {
                WordAddWindow addw = new WordAddWindow();
                addw.Show();
                if (addw.Ok.IsPressed)
                    LoadedBook.AddWord(addw.WordBoxAdd.Text, addw.TranslitionBox.Text);
            }
            else
            {
                MessageBox.Show("Библиотека переводов не загружена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DelTransl_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedBook != null)
            {
                LoadedBook.Word_Tr[word_position].DeleteTranslition(translition_position);
                WordTranslitionBox.Text = LoadedBook.Word_Tr[word_position].Word_translition[0];
            }
        }

        private void AddTranslition_Click(object sender, RoutedEventArgs e)
        {
            if(LoadedBook != null)
            {
                WordAddWindow addw = new WordAddWindow();
                addw.Show();
                if (addw.Ok.IsPressed)
                {
                    addw.WordBoxAdd.Text = LoadedBook.Word_Tr[word_position].Words;
                    addw.WordBoxAdd.IsReadOnly = true;
                    LoadedBook.Word_Tr[word_position].AddTranslition(addw.TranslitionBox.Text);
                    addw.WordBoxAdd.IsReadOnly = false;
                    WordTranslitionBox.Text = LoadedBook.Word_Tr[word_position].Word_translition[0];
                }
            }
        }

        private void NextTranslition_Click(object sender, RoutedEventArgs e)
        {
            if (LoadedBook != null)
            {
                WordTranslitionBox.Text = LoadedBook.Word_Tr[word_position].Word_translition[translition_position + 1];
                translition_position++;
            }
        }
    }
}

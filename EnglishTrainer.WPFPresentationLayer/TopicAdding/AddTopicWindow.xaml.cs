using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnglishTrainer.WPFPresentationLayer.TopicAdding
{
    /// <summary>
    /// Interaction logic for AddTopicWindow.xaml
    /// </summary>
    public partial class AddTopicWindow : Window
    {
        public AddTopicWindow()
        {
            InitializeComponent();
            AddWord();
        }

        private void AddWord()
        {
            WordToAdd word = new WordToAdd();
            word.DeleteButtonClick += DeleteWordButtonClicked;
            StackOfWords.Children.Add(word);                
        }

        private void DeleteWordButtonClicked(WordToAdd word)
        {
            StackOfWords.Children.Remove(word);
        }

        private void AddWordButton_Click(object sender, RoutedEventArgs e)
        {
            AddWord();
        }
    }
}

using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DesctopClient.Infrastructure;
using EnglishTrainer.DesctopClient.Models;
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

namespace EnglishTrainer.DesctopClient.TopicAdding
{
    /// <summary>
    /// Interaction logic for AddTopicWindow.xaml
    /// </summary>
    public partial class AddTopicWindow : Window
    {
        private ITopicService _topicService;
        public AddTopicWindow(ITopicService topicService)
        {
            InitializeComponent();
            _topicService = topicService;
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

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<WordViewModel> words = new List<WordViewModel>();
            if (StackOfWords.Children.Count == 0)
            {
                MessageBox.Show("Can't save empty topic!");
                return;
            }
            if (TopicName.Text == String.Empty)
            {
                MessageBox.Show("Can't save nameless topic!");
                return;
            }

            foreach (WordToAdd word in StackOfWords.Children)
            {
                if (word.English == String.Empty || word.Ukrainian == String.Empty)
                {
                    MessageBox.Show("Can't have empty fields");
                    return;
                }
                WordViewModel wordViewModel = new WordViewModel(word.English, word.Ukrainian);
                words.Add(wordViewModel);
            }

            await HttpClientGetter.PostRequrestAsync<List<WordViewModel>, object>(@"https://localhost:5001/api/topic/" + $"?topicName={TopicName.Text}&userId=1", words);
            /*
            List<WordDTO> wordDTOs = new List<WordDTO>();
            foreach (var item in words)
            {
                wordDTOs.Add(Mapper.MapWordDTO(item));
            }
            _topicService.AddTopic(wordDTOs, TopicName.Text, 1);
            */
            this.Close();
        }
    }
}

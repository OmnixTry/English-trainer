using EnglishTrainer.WPFPresentationLayer.Models;
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

namespace EnglishTrainer.WPFPresentationLayer.WordChecking
{
    /// <summary>
    /// Interaction logic for TopicWindow.xaml
    /// </summary>
    public partial class TopicWindow : Window
    {
        //private ITopic topic { get; set; }
        private object topic { get; set; }

        public TopicWindow(IEnumerable<QuestoinViewModel> topic)
        {
            InitializeComponent();
            StackOfWords.Children.Add(new TextBlock() { Text = topic.First().Queston });
            
            /*topic = wordTopic;
            foreach (IWord word in wordTopic.Words)
            {
                StackOfWords.Children.Add(new DisplayWord(word));
            }*/
            
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            foreach (DisplayWord word in StackOfWords.Children)
            {
                word.Check();
            }
            float topicProgress = topic.Check();
            ResultProgress.SetProgress((int)(topicProgress * 100));
            ResultProgress.Visibility = Visibility.Visible;
            */
        }

        private void ClearButon_Click(object sender, RoutedEventArgs e)
        {
            /*
            foreach (DisplayWord word in StackOfWords.Children)
            {
                word.Clear();
            }
            ResultProgress.Visibility = Visibility.Collapsed;
            */
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

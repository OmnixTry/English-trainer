using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DAL.Interfaces;
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
        private ITopicService _topicService;

        public TopicWindow(IEnumerable<QuestionViewModel> topic, ITopicService topicService)
        {
            InitializeComponent();
            _topicService = topicService;
            
            foreach (QuestionViewModel questoin in topic)
            {
                StackOfWords.Children.Add(new DisplayWord(questoin));
            }
            
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            List<AnswerDTO> answers = new List<AnswerDTO>();
            foreach (DisplayWord word in StackOfWords.Children)
            {
                AnswerViewModel answer = new AnswerViewModel()
                {
                    Id = word.Question.Id,
                    Language = word.Question.TranslateIntoLanguage,
                    TopicId = word.Question.TopicId,
                    Answer = word.TranslationBox.Text
                };
                answers.Add(Mapper.MapAnswerDTO(answer));
            }

            IEnumerable<AnswerDTO> correctAnswerDTOs = _topicService.Check(answers);
            List<AnswerViewModel> correctAnswers = new List<AnswerViewModel>();
            foreach (AnswerDTO answer in correctAnswerDTOs)
            {
                correctAnswers.Add(Mapper.MapAnswer(answer));
            }

            foreach (DisplayWord word in StackOfWords.Children)
            {
                AnswerViewModel answer = correctAnswers.Where(a => a.Id == word.Question.Id).FirstOrDefault();
                if (answer != null)
                    word.DisplayImage(answer.IsCorrect);
                else
                    word.DisplayImage(false);
                word.DisableTranslation();                
            }
            ResultProgress.SetProgress(correctAnswers.Where(a => a.IsCorrect).Count() * 100 / correctAnswers.Count());
            ResultProgress.Visibility = Visibility.Visible;
        }

        private void ClearButon_Click(object sender, RoutedEventArgs e)
        {
            foreach (DisplayWord word in StackOfWords.Children)
            {
                word.EneableTranslation();
                word.ClearTranslation();
            }
            ResultProgress.Visibility = Visibility.Collapsed;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.WPFPresentationLayer.Models;
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

namespace EnglishTrainer.WPFPresentationLayer.WordChecking
{
    /// <summary>
    /// Interaction logic for ListOfTopics.xaml
    /// </summary>
    public partial class ListOfTopics : Window
    {
        private ITopicService _topicService;
        public ListOfTopics(ITopicService topicService)
        {
            InitializeComponent();
            _topicService = topicService;
            LoadTopics();
        }

        private void LoadTopics()
        {
            IEnumerable<TopicDTO> topicDTOs = _topicService.GetTopics();
            List<TopicViewModel> topics = new List<TopicViewModel>();

            foreach (var topic in topicDTOs)
            {
                TopicViewModel topicViewModel = Mapper.MapTopic(topic);
                TopicInList topicInList = new TopicInList(topicViewModel.Id, topicViewModel.Name, 0, 0);
                topicInList.TopicSelected += TopicPlayButtonClick;
                Topics.Children.Add(topicInList);
            }
        }

        void TopicPlayButtonClick(int topicId, EnglishTrainer.WPFPresentationLayer.Delegates.Language language)
        {
            IEnumerable<QuestoinDTO> questoinDTOs;
            switch (language)
            {
                case EnglishTrainer.WPFPresentationLayer.Delegates.Language.Ukrainian:
                    questoinDTOs = _topicService.GetUkrQuestoins(topicId);
                    break;
                case EnglishTrainer.WPFPresentationLayer.Delegates.Language.English:
                    questoinDTOs = _topicService.GetEngQuestoins(topicId);
                    break;
                default:
                    throw new InvalidOperationException("No such language available");
            }
            List<QuestionViewModel> questoinViewModels = new List<QuestionViewModel>();
            foreach (var question in questoinDTOs)
            {
                questoinViewModels.Add(Mapper.mapQuestion(question));
            }

            TopicWindow topicWindow = new TopicWindow(questoinViewModels, _topicService);
            topicWindow.Show();

            
        }
    }
}

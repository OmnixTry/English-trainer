using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DesctopClient.Infrastructure;
using EnglishTrainer.DesctopClient.Models;
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

namespace EnglishTrainer.DesctopClient.WordChecking
{
    /// <summary>
    /// Interaction logic for ListOfTopics.xaml
    /// </summary>
    public partial class ListOfTopics : Window
    {
        //private ITopicService _topicService;
        public ListOfTopics()
        {
            InitializeComponent();
            //_topicService = topicService;
            LoadTopicsAsync();
        }

        private async System.Threading.Tasks.Task LoadTopicsAsync()
        {
            //IEnumerable<TopicDTO> topicDTOs = _topicService.GetTopics();
            List<TopicViewModel> topics; //= new List<TopicViewModel>();

            topics = await HttpClientGetter.GetResultAsync<List<TopicViewModel>>(@"https://localhost:5001/api/topic/");

            //foreach (var item in topicDTOs)
            //    topics.Add(Mapper.MapTopic(item));

            foreach (var topic in topics)
            {
                //IEnumerable<TopicResultDTO> topicResultDTOs = _topicService.GetTopicResults(topic.Id);
                List<TopicResultViewModel> topicResultViewModels // = new List<TopicResultViewModel>();
                    = await HttpClientGetter.GetResultAsync<List<TopicResultViewModel>>(@"https://localhost:5001/api/topic/" + topic.Id.ToString() + @"/results/");
                //foreach (var result in topicResultDTOs)
                //{
                //    topicResultViewModels.Add(Mapper.MapTopicResult(result));
                //}

                int? engRes = topicResultViewModels
                    .Where(r => r.Language == Delegates.Language.Ukrainian)
                    .OrderByDescending(r => r.CompletionDate)
                    .FirstOrDefault()
                    ?.CorrectPercentage;
                int? ukrRes = topicResultViewModels
                    .Where(r => r.Language == Delegates.Language.English)
                    .OrderByDescending(r => r.CompletionDate)
                    .FirstOrDefault()
                    ?.CorrectPercentage;

                TopicInList topicInList = new TopicInList(topic.Id, topic.Name, engRes == null ? 0 : (int)engRes, ukrRes == null ? 0 : (int)ukrRes);
                topicInList.TopicSelected += TopicPlayButtonClick;
                Topics.Children.Add(topicInList);
            }
        }

        async void TopicPlayButtonClick(int topicId, EnglishTrainer.DesctopClient.Delegates.Language language)
        {
            List<QuestionViewModel> questoinViewModels = await
                HttpClientGetter.GetResultAsync<List<QuestionViewModel>>(@"https://localhost:5001/api/topic/" + topicId + @"/questions/?language=" + language);

            /*
            IEnumerable <QuestoinDTO> questoinDTOs;
            switch (language)
            {
                case EnglishTrainer.DesctopClient.Delegates.Language.Ukrainian:
                    questoinDTOs = _topicService.GetUkrQuestoins(topicId);
                    break;
                case EnglishTrainer.DesctopClient.Delegates.Language.English:
                    questoinDTOs = _topicService.GetEngQuestoins(topicId);
                    break;
                default:
                    throw new InvalidOperationException("No such language available");
            }
            */
            //List<QuestionViewModel> questoinViewModels = new List<QuestionViewModel>();
            //foreach (var question in questoinDTOs)
            //{
            //   questoinViewModels.Add(Mapper.mapQuestion(question));
            //}

            TopicWindow topicWindow = new TopicWindow(questoinViewModels);
            topicWindow.Show();

            
        }
    }
}

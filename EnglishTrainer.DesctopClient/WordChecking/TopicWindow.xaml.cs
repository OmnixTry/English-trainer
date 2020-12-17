using BLL.DataTransferObjects;
using BLL.Interfaces;
using EnglishTrainer.DAL.Interfaces;
using EnglishTrainer.DesctopClient.Infrastructure;
using EnglishTrainer.DesctopClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for TopicWindow.xaml
    /// </summary>
    public partial class TopicWindow : Window
    {
        //private ITopic topic { get; set; }
        //private ITopicService _topicService;

        public TopicWindow(IEnumerable<QuestionViewModel> topic)
        {
            InitializeComponent();
            //_topicService = topicService;
            
            foreach (QuestionViewModel questoin in topic)
            {
                StackOfWords.Children.Add(new DisplayWord(questoin));
            }
            
        }

        private async void CheckButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            List<AnswerViewModel> answers = new List<AnswerViewModel>();
            foreach (DisplayWord word in StackOfWords.Children)
            {
                AnswerViewModel answer = new AnswerViewModel()
                {
                    Id = word.Question.Id,
                    Language = word.Question.TranslateIntoLanguage,
                    TopicId = word.Question.TopicId,
                    Answer = word.TranslationBox.Text
                };
                answers.Add(answer);
            }
       
            List<AnswerViewModel> correctAnswers;
            correctAnswers = await HttpClientGetter.PostRequrestAsync
                <List<AnswerViewModel>, List<AnswerViewModel>>(@"https://localhost:5001/api/answer/", answers);
            /*
            string serializedData = JsonConvert.SerializeObject(answers);
            //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(serializedData);
            //ByteArrayContent content = new ByteArrayContent(buffer);
            StringContent content = new StringContent(serializedData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateCertificate);


            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.ServerCertificateValidationCallback +=
            //    (sender, cert, chain, sslPolicyErrors) => { return true; };
            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            using (HttpClient client = new HttpClient(handler)) 
            {
                HttpResponseMessage response = client.PostAsync(@"https://localhost:5001/api/answer/", content).Result;
                var text = await response.Content.ReadAsStringAsync();
                correctAnswers = await HttpContentExtensions.ReadAsJsonAsync<List<AnswerViewModel>>(response.Content);
            }
            */
            //IEnumerable<AnswerDTO> correctAnswerDTOs = _topicService.Check(answers);
            //List<AnswerViewModel> correctAnswers = new List<AnswerViewModel>();
            //foreach (AnswerDTO answer in correctAnswerDTOs)
            //{
            //    correctAnswers.Add(Mapper.MapAnswer(answer));
            //}

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

using BLL.BusinessModels;
using BLL.Interfaces;
using BLL.Services;
using EnglishTrainer.DAL.Repositories;
using EnglishTrainer.DesctopClient.Infrastructure;
using EnglishTrainer.DesctopClient.TopicAdding;
using EnglishTrainer.DesctopClient.WordChecking;
using Ninject;
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

namespace EnglishTrainer.DesctopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TopicCheckButton.ClickAction = TopicCheckButtonClick;
            AddNewTopicButton.ClickAction = AddTopicButtonClick;
            //DictonaryButton.ClickAction = UnderConstruction;
            QuitButton.ClickAction = Quit;
        }

        private static void TopicCheckButtonClick()
        {
            //TODO Dependency injection
            //ListOfTopics listOfTopics = new ListOfTopics(new TopicService(new EFVocabularyUnitOfWork(new EnglishTrainer.DAL.EF.VocabularyContext()), new Checker()));
            //IKernel kernel = new StandardKernel(new BLLBindings());
            ListOfTopics listOfTopics = new ListOfTopics();
            listOfTopics.ShowDialog();
        }

        private static void AddTopicButtonClick()
        {
            IKernel kernel = new StandardKernel(new BLLBindings());
            //AddTopicWindow addTopicWindow = new AddTopicWindow(new TopicService(new EFVocabularyUnitOfWork(new EnglishTrainer.DAL.EF.VocabularyContext()), new Checker()));
            AddTopicWindow addTopicWindow = new AddTopicWindow(kernel.Get<ITopicService>());
            addTopicWindow.ShowDialog();
        }
        private static void UnderConstruction()
        {
            MessageBox.Show("Under Construction", "Woops", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Quit()
        {
            this.Close();
        }


        //private void TopicCheckButton_Click()
        //{
            //TODO
            /*
            DataBase.DBWordLoader loader = new DataBase.DBWordLoader();
            var v = new WordChecking.GUIElements.TopicWindow(new WordChecking.EnglishToUkrainianTopic("dddd", loader.LoadWordsOfTopics("starter1")));
            v.ShowDialog();
            */
        //}
    }
}

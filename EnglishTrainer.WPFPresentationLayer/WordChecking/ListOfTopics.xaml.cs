using BLL.Interfaces;
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
            
        }
    }
}

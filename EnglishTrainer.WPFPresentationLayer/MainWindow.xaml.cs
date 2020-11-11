﻿using System;
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

namespace EnglishTrainer.WPFPresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TopicCheckButton.ClickAction = TopicCheckButton_Click;
            AddNewTopicButton.ClickAction = UnderConstruction;
            //DictonaryButton.ClickAction = UnderConstruction;
            QuitButton.ClickAction = Quit;
        }

        private static void TopicsCheckButtonClick()
        {

        }

        private static void UnderConstruction()
        {
            MessageBox.Show("Under Construction", "Woops", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Quit()
        {
            this.Close();
        }

        private void TopicCheckButton_Click()
        {
            //TODO
            /*
            DataBase.DBWordLoader loader = new DataBase.DBWordLoader();
            var v = new WordChecking.GUIElements.TopicWindow(new WordChecking.EnglishToUkrainianTopic("dddd", loader.LoadWordsOfTopics("starter1")));
            v.ShowDialog();
            */
        }
    }
}

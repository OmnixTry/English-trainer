using EnglishTrainer.WPFPresentationLayer.Delegates;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishTrainer.WPFPresentationLayer.WordChecking
{
    /// <summary>
    /// Interaction logic for TopicInList.xaml
    /// </summary>
    public partial class TopicInList : UserControl
    {
        public event TopicSelection EngToUkrCkick;
        public event TopicSelection UkrToEngCkick;

        public int TopicId { get; set; }
        public TopicInList(int topicID, string TopicName, int EngToUkrPercentage, int UkrToEngpercentage)
        {
            InitializeComponent();
        }

        private void FromEnglishButton_Click(object sender, RoutedEventArgs e)
        {
            this.EngToUkrCkick?.Invoke(TopicId, Delegates.Language.Ukrainian);
        }

        private void FromUkrainianButton_Click(object sender, RoutedEventArgs e)
        {
            this.UkrToEngCkick?.Invoke(TopicId, Delegates.Language.Ukrainian);
        }
    }
}

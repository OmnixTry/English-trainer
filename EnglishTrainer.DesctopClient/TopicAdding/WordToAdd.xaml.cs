using EnglishTrainer.DesctopClient.Delegates;
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

namespace EnglishTrainer.DesctopClient.TopicAdding
{
    /// <summary>
    /// Interaction logic for WordToAdd.xaml
    /// </summary>
    public partial class WordToAdd : UserControl
    {
        public event wordDeleting DeleteButtonClick;    
        public WordToAdd()
        {
            InitializeComponent();
        }
        public string English
        {
            get
            {
                return EngTrtanslation.Text;
            }
        }

        public string Ukrainian
        {
            get
            {
                return UkrTrtanslation.Text;
            }
        }

        private void Deletebutton_Click(object sender, RoutedEventArgs e)
        {
            DeleteButtonClick?.Invoke(this);
        }
    }
}

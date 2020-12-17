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

namespace EnglishTrainer.DesctopClient.Menu
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string ButtonTitle { get; set; }
        public delegate void ButtonClickAction();
        public ButtonClickAction ClickAction { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClickAction();
        }
    }
}

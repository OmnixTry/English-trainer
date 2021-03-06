﻿using System;
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
    /// Interaction logic for TopicProgressBar.xaml
    /// </summary>
    public partial class TopicProgressBar : UserControl
    {
        public TopicProgressBar()
        {
            InitializeComponent();
        }

        public void SetProgress(int progressPercentage = 0)
        {
            TopicProgressText.Text = progressPercentage.ToString() + "%";
            TopicProgressPercentBar.Value = progressPercentage;
        }
    }
}

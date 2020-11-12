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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EnglishTrainer.WPFPresentationLayer.Models;

namespace EnglishTrainer.WPFPresentationLayer.WordChecking
{
    /// <summary>
    /// Interaction logic for DisplayWord.xaml
    /// </summary>
    public partial class DisplayWord : UserControl
    {
        public QuestionViewModel Question { get; }
        public DisplayWord(QuestionViewModel questionViewModel)
        {
            InitializeComponent();
            Question = questionViewModel;
            OriginalWord.Text = Question.Question;
        }

        /// <summary>
        /// Displays the image marking if the input answer is correct
        /// </summary>
        /// <param name="result">true: displays correct image; false: displays incorrect image</param>
        public void DisplayImage(bool result)
        {
            BitmapImage bitmapCorrectnessImage = new BitmapImage();
            if (result)
            {
                bitmapCorrectnessImage.BeginInit();
                bitmapCorrectnessImage.UriSource = new Uri("/img/right.png", UriKind.Relative);
                bitmapCorrectnessImage.EndInit();

                CorrectnessImage.Source = bitmapCorrectnessImage;
            }
            else
            {
                bitmapCorrectnessImage.BeginInit();
                bitmapCorrectnessImage.UriSource = new Uri("/img/wrong.png", UriKind.Relative);
                bitmapCorrectnessImage.EndInit();

                CorrectnessImage.Source = bitmapCorrectnessImage;
            }
        }

        public void DisableTranslation()
        {
            TranslationBox.IsReadOnly = true;
        }

        public void EneableTranslation()
        {
            TranslationBox.IsReadOnly = false;
        }

        public void ClearTranslation()
        {
            TranslationBox.Text = String.Empty;
            CorrectnessImage.Source = null;
        }
    }
}

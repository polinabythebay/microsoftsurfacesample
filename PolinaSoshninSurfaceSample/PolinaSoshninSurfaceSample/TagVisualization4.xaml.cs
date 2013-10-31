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
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace PolinaSoshninSurfaceSample
{
    /// <summary>
    /// Interaction logic for TagVisualization4.xaml
    /// </summary>
    public partial class TagVisualization4 : TagVisualization
    {
        public TagVisualization4()
        {
            InitializeComponent();
        }

        private void TagVisualization4_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: customize TagVisualization4's UI based on this.VisualizedTag here
            MessageText.Inlines.Add(new Bold(new Run("Greece fun facts! \n")));
            MessageText.Inlines.Add(new Bold(new Run("Capital: Athens \n")));
            MessageText.Inlines.Add(new Bold(new Run("Official language: Greek \n")));
            MessageText.Inlines.Add(new Bold(new Run("Population: 11 million \n")));
            MessageText.Inlines.Add(new Bold(new Run("Food: Greece has a culinary tradition going back 4,000  years and is characterized by the mediterranean diet of wheat, olive oil, and wine. \n")));

        }
    }
}

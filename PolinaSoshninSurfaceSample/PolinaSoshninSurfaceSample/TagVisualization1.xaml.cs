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
    /// Interaction logic for TagVisualization1.xaml
    /// </summary>
    public partial class TagVisualization1 : TagVisualization
    {
        public TagVisualization1()
        {
            InitializeComponent();
        }

        private void TagVisualization1_Loaded(object sender, RoutedEventArgs e)
        {
            MessageText.Inlines.Add(new Bold(new Run("Germany fun facts! \n")));
            MessageText.Inlines.Add(new Bold(new Run("Capital: Berlin \n")));
            MessageText.Inlines.Add(new Bold(new Run("Official language: German \n")));
            MessageText.Inlines.Add(new Bold(new Run("Population: 80 million \n")));
            MessageText.Inlines.Add(new Bold(new Run("Food: Bread is a significant part of German cuisine. \n " + "About 600 main types of breads and 1200 types of pastries are produced in the country.")));

               
            //TODO: customize TagVisualization1's UI based on this.VisualizedTag here
            //TODO: customize TagVisualization1's UI based on this.VisualizedTag here
        }
    }
}

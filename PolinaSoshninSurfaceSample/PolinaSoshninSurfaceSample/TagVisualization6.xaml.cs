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
    /// Interaction logic for TagVisualization6.xaml
    /// </summary>
    public partial class TagVisualization6 : TagVisualization
    {
        public TagVisualization6()
        {
            InitializeComponent();
        }

        private void TagVisualization6_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: customize TagVisualization6's UI based on this.VisualizedTag here
            MessageText.Inlines.Add(new Bold(new Run("Morocco fun facts! \n")));
            MessageText.Inlines.Add(new Bold(new Run("Capital: Rabat \n")));
            MessageText.Inlines.Add(new Bold(new Run("Official language: Arabic \n")));
            MessageText.Inlines.Add(new Bold(new Run("Population: 33 million \n")));
            MessageText.Inlines.Add(new Bold(new Run("Food: The main national dish is couscous. A popular desert is kaab el ghzal, a pastry stuffed with almond paste and topped with sugar \n")));

        }
    }
}

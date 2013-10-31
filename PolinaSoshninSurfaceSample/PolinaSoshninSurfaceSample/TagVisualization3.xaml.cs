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
    /// Interaction logic for TagVisualization3.xaml
    /// </summary>
    public partial class TagVisualization3 : TagVisualization
    {
        public TagVisualization3()
        {
            InitializeComponent();
        }

        private void TagVisualization3_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: customize TagVisualization3's UI based on this.VisualizedTag here
            base.OnInitialized(e);

            // Query the registry to find out where the sample media is stored.
            const string shellKey =
               @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\explorer\Shell Folders";

            string videosPath =
           (string)Microsoft.Win32.Registry.GetValue(shellKey, "CommonVideo", null) + @"\Sample Videos";

            // The name of the video.
            string targetVideo = @"C:\Users\hcilab\Desktop\Polina\CS320HW2Media\greece.mp4";

            // string targetVideo = @"Wildlife.wmv";
            // Create a ScatterViewItem control and add it to the Items collection.
            ScatterViewItem item = new ScatterViewItem();
            videoScatter.Items.Add(item);

            // Create a MediaElement object.
            MediaElement video = new MediaElement();

            video.LoadedBehavior = MediaState.Manual;
            video.UnloadedBehavior = MediaState.Manual;

            // The media dimensions are not available until the MediaOpened event.
            video.MediaOpened += delegate
            {
                // Size the ScatterViewItem control according to the video size.
                item.Height = video.NaturalVideoHeight / 2;
                item.Width = video.NaturalVideoWidth / 2;


            };

            // Set the Content to the video.
            item.Content = video;

            // Get the video if it exists.
            if (System.IO.File.Exists(targetVideo))
            {
                video.Source = new Uri(targetVideo);
                video.Play();
            }
            else
            {
                item.Content = "Video not found";
            }



        }
    }
}

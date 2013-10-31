using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Collections.ObjectModel;
using PolinaSoshninHW2;

namespace PolinaSoshninSurfaceSample
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// This class covers how to:
    /// Drag items from a LibraryContainer to a ScatterView and back
    /// Drag items between a LibraryStack/Library Bar
    /// Change the background of the ScatterView to an image 
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {

        //Use the Drag and Drop API to populate the Library Stacks and allow for interaction with the ScatterView
        private ObservableCollection<PhotoData> libraryItems = new ObservableCollection<PhotoData>();
        private ObservableCollection<PhotoData> scatterItems = new ObservableCollection<PhotoData>();

        public ObservableCollection<PhotoData> LibraryItems
        {
            get { return libraryItems; }
        }

        public ObservableCollection<PhotoData> ScatterItems
        {
            get { return scatterItems; }
        }
        
        ///populates the libraryItems collection 
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;
            LibraryItems.Add(new PhotoData("Images/greece.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece1.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece2.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece3.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece4.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece5.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece6.jpg"));
            LibraryItems.Add(new PhotoData("Images/greece7.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany1.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany2.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany3.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany4.jpg"));
            LibraryItems.Add(new PhotoData("Images/germany5.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco1.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco2.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco3.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco4.jpg"));
            LibraryItems.Add(new PhotoData("Images/morocco5.jpg"));    
        }

        ///Allows you to drag items from the LibraryContainer to the ScatterView and drop them
        private void Scatter_Drop(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData e1 = (PhotoData)e.Cursor.Data;

            //if it isn't already on the Scatterview, add it to the source collection
            if (!ScatterItems.Contains(e.Cursor.Data))
            {
                e1 = (PhotoData)e.Cursor.Data;
                ScatterItems.Add(e1);
            }

            //get the ScatterViewItem that Scatter automatically generated.
            ScatterViewItem svi = scatter.ItemContainerGenerator.ContainerFromItem(e.Cursor.Data) as ScatterViewItem;
        
            svi.Visibility = System.Windows.Visibility.Visible;
            svi.Width = e.Cursor.Visual.ActualWidth;
            svi.Height = e.Cursor.Visual.ActualHeight;
            svi.Center = e.Cursor.GetPosition(scatter);
            svi.Orientation = e.Cursor.GetOrientation(scatter);
            svi.Background = Brushes.Transparent;

            //setting e.handled to true ensures that default behavior is not performed
            e.Handled = true;   
        }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }


        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }


        /// Will be used when the user touches an element on the scatterview
        /// will gather the required data for the drag and drop operation and start it
        /// Once user has dropped item, either a DragCanceled or DragCompleted event will be fired,
        /// depending on where the item is dropped 
        /// If they drop the item on the ScatterView or LibraryContainer the DragCompleted Event will fire
        /// If they drop it to the left of the right of the LibraryContainer the DragCanceled event will fire 
        private void Scatter_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            FrameworkElement findSource = e.OriginalSource as FrameworkElement;
            ScatterViewItem draggedElement = null;

            //find the ScatterViewItem object that is being touched 
            while (draggedElement == null && findSource != null)
            {
                if ((draggedElement = findSource as ScatterViewItem) == null)
                {
                    findSource = VisualTreeHelper.GetParent(findSource) as FrameworkElement;
                }

            }
            if (draggedElement == null)
            {
                return;
            }
            PhotoData data = draggedElement.Content as PhotoData;

            //create the cursor visual
            ContentControl cursorVisual = new ContentControl()
            {
                Content= draggedElement.DataContext,
                Style = FindResource("CursorStyle") as Style
            };

            //create the list of input devices 
            //add the touches that are currently captured within the dragged elt and
            //the current touch (if it isn't already in the list)
            List<InputDevice> devices = new List<InputDevice>();
            devices.Add(e.TouchDevice);
            foreach (TouchDevice touch in draggedElement.TouchesCapturedWithin)
            {
                if (touch != e.TouchDevice)
                {
                    devices.Add(touch);
                }

            }
            //get the drag source object
            ItemsControl dragSource = ItemsControl.ItemsControlFromItemContainer(draggedElement);
            //the scatterview object that the cursor is dragged out from
            SurfaceDragDrop.BeginDragDrop(
                dragSource,
                draggedElement,
                cursorVisual,
                draggedElement.DataContext,
                devices,
                DragDropEffects.Move);

            //this prevents the default touch operator from happening
            e.Handled = true;

            //hide the scatterviewitem for now. we will remove it if the dragdrop is successful
            draggedElement.Visibility = Visibility.Hidden;
        }

        //will complete the drag operation by removing the item from the source collection
        //if the current effect was copy then you would not remove it 
        private void Scatter_DragCompleted(object sender, SurfaceDragCompletedEventArgs e)
        {
            if (e.Cursor.CurrentTarget != scatter && e.Cursor.Effects == DragDropEffects.Move)
            {
                ScatterItems.Remove(e.Cursor.Data as PhotoData);
                e.Handled = true;
            }
        }

        //will restore the scatterviewitem to visible when the user drops the item where it is not able
        //to be dropped
        private void Scatter_DragCanceled(object sender, SurfaceDragDropEventArgs e)
        {
            PhotoData data = e.Cursor.Data as PhotoData;
            ScatterViewItem svi = scatter.ItemContainerGenerator.ContainerFromItem(data) as ScatterViewItem;
            if (svi != null)
            {
                svi.Visibility = Visibility.Visible;
            }
        }
       
        /// Changes the background of the ScatterView to an image after a click event.
        /// NOTE: This uses an absolute path
        private void Germany_click(object sender, RoutedEventArgs e)
        {
            ImageBrush a3= new ImageBrush();
            Uri myUri = new Uri(@"C:\Users\balichmac1\Desktop\Polina\CS320HW2Media\germanybackground.jpg", UriKind.Absolute);
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            a3.ImageSource = bitmapSource;
            scatter.Background = a3;
        }

        private void Greece_click(object sender, RoutedEventArgs e)
        {
            ImageBrush a4 = new ImageBrush();
            Uri myUri = new Uri(@"C:\Users\balichmac1\Desktop\Polina\CS320HW2Media\greecebackground.jpg", UriKind.Absolute);
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            a4.ImageSource = bitmapSource;
            scatter.Background = a4;
        }

        private void Morocco_click(object sender, RoutedEventArgs e)
        {
            ImageBrush a5 = new ImageBrush();
            Uri myUri = new Uri(@"C:\Users\balichmac1\Desktop\Polina\CS320HW2Media\moroccobackground.jpg", UriKind.Absolute);
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];
            a5.ImageSource = bitmapSource;
            scatter.Background = a5;
        }

        /// Changes the background of the ScatterView back to the original Blue
        private void HelloButton_click(object sender, RoutedEventArgs e)
        {
            scatter.Background = Brushes.DarkBlue;
        }
    }
}
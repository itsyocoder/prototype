using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using prototype.View;
using prototype.ViewModel;

namespace prototype
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> EventList { get; set; } = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
         

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool isMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            {
                if(isMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    isMaximized = false;
                }
            }
        }


        private void Dashboardbtn(object sender, RoutedEventArgs e)
        {

            foreach (UIElement element in MenuContainer.Children)
            {
                if(element is Button button)
                {
                    button.Tag = false;
                }
            }

            Button? clickedButton = sender as Button;
            if(clickedButton != null)
            {
                clickedButton.Tag = true;
            }

            //display na part
            dashboard dashboard = new dashboard();
            MainDisplay.Content = dashboard;
        }

        private void Ceeventbtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in MenuContainer.Children)
            {
                if (element is Button button)
                {
                    button.Tag = false;
                }
            }

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Tag = true;
            }

            // Create an instance of Cevent and display it in MainDisplay
            Cevent cevent = new Cevent();
            MainDisplay.Content = cevent;
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in MenuContainer.Children)
            {
                if (element is Button button)
                {
                    button.Tag = false;
                }
            }

            Button? clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.Tag = true;
            }

            if (MainDisplay != null)
            {
                Event eventView = new Event();

                if(Application.Current.MainWindow is MainWindow mainWindow)
                {
                    foreach(string eventDetails in mainWindow.EventList)
                    {
                        Button eventButton = new Button
                        {
                            Content = eventDetails,
                            Width = 100,
                            Height = 100,
                            Background = Brushes.LightBlue
                        };

                        if (eventView.FindName("ButtonContainer") is Panel container)
                        {
                            container.Children.Add(eventButton);
                        }
                    }
                }
                MainDisplay.Content = eventView;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
   
}
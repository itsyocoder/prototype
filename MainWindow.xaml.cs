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
            dashboardnoevent dashboardnoevent = new dashboardnoevent();
            MainDisplay.Content = dashboardnoevent;
        }

        private void Ceeventbtn(object sender, RoutedEventArgs e)
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

            Cevent Cevent = new Cevent(MainDisplay);
            MainDisplay.Content = Cevent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
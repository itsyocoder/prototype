using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace prototype.View
{
    /// <summary>
    /// Interaction logic for verify.xaml
    /// </summary>
    public partial class verify : Window
    {
        public verify()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnmin_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnexit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnverify_click(object sender, RoutedEventArgs e)
        {

            var loginWindow = new Login();

            loginWindow.Show();

            this.Close();
        }

        private void verifyuser_TextChanged(object sender, TextChangedEventArgs e)
        {


        }
    }
}

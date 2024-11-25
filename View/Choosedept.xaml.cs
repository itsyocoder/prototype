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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prototype.View
{
    /// <summary>
    /// Interaction logic for Choosedept.xaml
    /// </summary>
    public partial class Choosedept : UserControl
    {
        private ContentControl MainDisplay;
        public Choosedept(ContentControl mainDisplay)
        {
            InitializeComponent();
            MainDisplay = mainDisplay;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (MainDisplay == null)
            {
                MessageBox.Show("MainDisplay is not initialized.");
                return;
            }

            try
            {
                MainDisplay.Content = new Cevent(MainDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

    }
}

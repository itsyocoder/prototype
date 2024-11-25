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
    /// Interaction logic for Cevent.xaml
    /// </summary>
    public partial class Cevent : UserControl
    {
        //para mu display ang another user control view
        public ContentControl MainDisplay {  get; set; }
        public Cevent(ContentControl mainDisplay)
        {
            InitializeComponent();
            MainDisplay = mainDisplay;
        }

        private void incdept_click(object sender, RoutedEventArgs e)
        {
            if (MainDisplay == null)
            {
                MessageBox.Show("MainDisplay is not initialized.");
                return;
            }

            try
            {
                Choosedept choosedept = new Choosedept();
                MainDisplay.Content = choosedept;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void Nameevent(object sender, RoutedEventArgs e)
        {
            if (MainDisplay == null)
            {
                MessageBox.Show("MainDisplay is not initialized.");
                return;
            }

            try
            {
                Nameofevent nameofevent = new Nameofevent(MainDisplay);
                MainDisplay.Content = nameofevent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}

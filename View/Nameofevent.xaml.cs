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
    /// Interaction logic for Nameofevent.xaml
    /// </summary>
    public partial class Nameofevent : UserControl
    {
        private ContentControl MainDisplay;
        private Button NameEventButton;
        public Nameofevent(ContentControl mainDisplay, Button nameEventButton)
        {
            InitializeComponent();
            MainDisplay = mainDisplay;
            NameEventButton = nameEventButton;
        }


        private void Confirm_click(object sender, RoutedEventArgs e)
        {
            
            if(MainDisplay == null)
            {
                MessageBox.Show("MainDisplay is not initialized.");
                return;
            }

            string eventName = EventNameTextBox.Text.Trim();

            if(string.IsNullOrEmpty(eventName) )
            {
                MessageBox.Show("Please enter a valid event name.");
                return;
            }

            try
            {
                if (NameEventButton != null)
                {
                    NameEventButton.Content = $"Name Of Event: {eventName}";
                }

                MainDisplay.Content = new Cevent(MainDisplay);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
            }
            
        }

    }
}

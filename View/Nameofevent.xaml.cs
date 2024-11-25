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
        public Nameofevent(ContentControl mainDisplay)
        {
            InitializeComponent();
            MainDisplay = mainDisplay;
        }

        private void Confirm_click(object sender, RoutedEventArgs e)
        {
            /*
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
                Cevent cevent = new Cevent(MainDisplay);

                // Update the TextBlock in Cevent with the event name
                TextBlock eventLabel = cevent.FindName("EventLabel") as TextBlock;
                if (eventLabel != null)
                {
                    eventLabel.Text = $"Name Of Event: {eventName}";
                }

                MainDisplay.Content = cevent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
            }
            */
        }

    }
}

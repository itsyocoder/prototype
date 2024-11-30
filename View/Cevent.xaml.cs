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
using Microsoft.Data.SqlClient;

namespace prototype.View
{
    public partial class Cevent : UserControl
    {
        // SQL Server connection string
        private readonly string connectionString = @"Server=MSI\SQLEXPRESS01; Database=LoginDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Cevent()
        {
            InitializeComponent();
            
        }

        private void choosedept(object sender, RoutedEventArgs e)
        {
            // Collect data from the form
            string eventName = EventNameTextBox.Text; // Get event name directly
            DateTime? startDate = StartDatePicker.SelectedDate; // Nullable to check for null values
            DateTime? endDate = EndDatePicker.SelectedDate;
            ComboBoxItem startTimeItem = (ComboBoxItem)StartTimeComboBox.SelectedItem;
            ComboBoxItem endTimeItem = (ComboBoxItem)EndTimeComboBox.SelectedItem;

            if (string.IsNullOrEmpty(eventName) || startDate == null || endDate == null || startTimeItem == null || endTimeItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Parse time from ComboBox items
            TimeSpan startTime = TimeSpan.Parse(startTimeItem.Content.ToString());
            TimeSpan endTime = TimeSpan.Parse(endTimeItem.Content.ToString());

            // Prepare event details
            var eventDetails = new Dictionary<string, object>
            {
                { "EventName", eventName },
                { "StartDate", startDate.Value },
                { "EndDate", endDate.Value },
                { "StartTime", startTime },
                { "EndTime", endTime }
            };

            // Call method to save data to the database
            bool isSaved = SaveEventToDatabase(eventDetails);

            // Navigate to Choosedept view if data is saved successfully
            if (isSaved)
            {
                if (Application.Current.MainWindow is MainWindow mainWindow)
                {
                    mainWindow.MainDisplay.Content = new Choosedept();
                }
            }
        }


        private bool SaveEventToDatabase(Dictionary<string, object> eventDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Events (EventName, StartDate, EndDate, StartTime, EndTime) VALUES (@EventName, @StartDate, @EndDate, @StartTime, @EndTime)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use proper parameterized queries to match SQL Server types
                        command.Parameters.AddWithValue("@EventName", eventDetails["EventName"]);
                        command.Parameters.AddWithValue("@StartDate", eventDetails["StartDate"]);
                        command.Parameters.AddWithValue("@EndDate", eventDetails["EndDate"]);
                        command.Parameters.AddWithValue("@StartTime", eventDetails["StartTime"]);
                        command.Parameters.AddWithValue("@EndTime", eventDetails["EndTime"]);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Event successfully saved.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date or time format. Please check your input.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return false;
        }
//

        //www
    }

}

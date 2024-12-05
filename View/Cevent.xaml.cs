using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace prototype.View
{
    public partial class Cevent : UserControl
    {
        // SQL Server connection string
        private readonly string connectionString = @"Server=MSI\SQLEXPRESS01; Database=LoginDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";
        public ContentControl MainDisplay { get; set; }

        public Cevent(ContentControl mainDisplay)
        {
            InitializeComponent();
            MainDisplay = mainDisplay;
        }

        private void choosedept_btn(object sender, RoutedEventArgs e)
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

            // Save event to the database and get the EventID
            int eventID = SaveEventToDatabase(eventDetails);

            if (eventID != -1)
            {
                if (MainDisplay == null)
                {
                    MessageBox.Show("MainDisplay is not initialized.");
                    return;
                }

                try
                {
                    Choosedept choosedept_btn = new Choosedept(MainDisplay, eventID); // Pass eventID to Choosedept
                    MainDisplay.Content = choosedept_btn;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}\n\n{ex.StackTrace}");
                }
            }
        }

        private int SaveEventToDatabase(Dictionary<string, object> eventDetails)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Events (EventName, StartDate, EndDate, StartTime, EndTime) OUTPUT INSERTED.EventID VALUES (@EventName, @StartDate, @EndDate, @StartTime, @EndTime)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventName", eventDetails["EventName"]);
                        command.Parameters.AddWithValue("@StartDate", eventDetails["StartDate"]);
                        command.Parameters.AddWithValue("@EndDate", eventDetails["EndDate"]);
                        command.Parameters.AddWithValue("@StartTime", eventDetails["StartTime"]);
                        command.Parameters.AddWithValue("@EndTime", eventDetails["EndTime"]);

                        connection.Open();
                        return (int)command.ExecuteScalar(); // Get the EventID of the newly inserted row
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1; // Return a default value indicating failure
            }
        }
    }
}

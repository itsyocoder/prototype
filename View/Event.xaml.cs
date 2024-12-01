using System;
using System.Data;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace prototype.View
{
    public partial class Event : UserControl
    {
        // Connection string for your SQL Server
        private readonly string connectionString = @"Server=MSI\SQLEXPRESS01; Database=LoginDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True";

        public Event()
        {
            InitializeComponent();
            LoadEventData(); // Load the data when the UserControl initializes
        }

        private void LoadEventData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Events"; // Query to get all data from the Events table
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the DataGrid
                    EventDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                // Show error message if fetching fails
                System.Windows.MessageBox.Show($"Error loading data: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}

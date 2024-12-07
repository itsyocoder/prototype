using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace prototype.View
{
    public partial class list : UserControl
    {
        private readonly string DepartmentName;
        private readonly int EventID;

        public list(ContentControl mainDisplay, string departmentName, int eventID)
        {
            InitializeComponent();
            DepartmentName = departmentName;
            EventID = eventID;

            LoadDepartmentDetails();
        }

        private void LoadDepartmentDetails()
        {
            // Display the department name
            DepartmentNameText.Text = DepartmentName;

            // Example of loading details - replace with actual database query if needed
            List<DetailModel> details = new List<DetailModel>
            {
                new DetailModel { Detail = "Example Detail 1" },
                new DetailModel { Detail = "Example Detail 2" },
                new DetailModel { Detail = "Example Detail 3" }
            };

            DetailsListView.ItemsSource = details;
        }

        private void PerformAction_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null || button.Tag == null) return;

            string detail = button.Tag.ToString();
            MessageBox.Show($"Performing action for: {detail}", "Action", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    public class DetailModel
    {
        public string Detail { get; set; }
    }
}

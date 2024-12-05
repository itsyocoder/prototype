using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace prototype.ViewModel
{
    public class DisplaydeptViewModel
    {
        public ObservableCollection<DepartmentViewModel> SelectedDepartments { get; set; }
        public ICommand NavigateToListCommand { get; set; }
        public int EventID { get; }

        public DisplaydeptViewModel(int eventId)
        {
            EventID = eventId;

            // Load selected departments based on the eventId (stubbed here for example)
            SelectedDepartments = new ObservableCollection<DepartmentViewModel>
            {
                new DepartmentViewModel { Name = "BED", Icon = (ImageBrush)App.Current.FindResource("dept1") },
                new DepartmentViewModel { Name = "CAE", Icon = (ImageBrush)App.Current.FindResource("dept2") },
                new DepartmentViewModel { Name = "CAFAE", Icon = (ImageBrush)App.Current.FindResource("dept3") }

                // Add departments based on eventId
            };

            NavigateToListCommand = new RelayCommand<DepartmentViewModel>(NavigateToList);
        }

        private void NavigateToList(DepartmentViewModel department)
        {
            // Handle navigation to List.xaml
            System.Windows.MessageBox.Show($"Navigating to List.xaml for {department.Name} and EventID {EventID}");
        }
    }

    public class DepartmentViewModel
    {
        public string Name { get; set; }
        public ImageBrush Icon { get; set; }
    }
}

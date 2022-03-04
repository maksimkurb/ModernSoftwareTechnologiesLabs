using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class MainViewModel
    {
        public PeopleModel People { get; set; }
        public ICommand ClickCommand { get; set; }
        public MainViewModel()
        {
            People = new PeopleModel
            {
                FirstName = "First name",
                LastName = "Last name"
            };
            ClickCommand = new ClickCommand(arg => ClickMethod());
        }

        private void ClickMethod()
        {
            MessageBox.Show("Person: " + People.FirstName + " " + People.LastName);
        }
    }
}

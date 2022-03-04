using System.ComponentModel;

namespace WpfApp1.Model
{
    class PeopleModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (FirstName == value) return;
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (LastName == value) return;
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

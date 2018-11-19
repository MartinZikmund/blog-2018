using Xamarin.Forms;

namespace MyAwesomeApp.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private string _greeting = "Hello";

        public string Greeting
        {
            get => _greeting;
            set
            {
                _greeting = value;
                OnPropertyChanged();
            }
        }
    }
}

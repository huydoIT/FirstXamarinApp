using FirstXamarinApp.Ultil;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand CommandLogin => new Command(cmd_Login);
        public ICommand CommandCancel => new Command(cmd_Cancel);
        private string _username = "";
        private string _password = "";

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private async void cmd_Login()
        {
            try
            {
                var person = await firebaseHelper.GetPerson(Username);
                if (person != null && person.Password.Equals(Password))
                {
                    Application.Current.MainPage.Navigation.PushAsync(new MainPage());
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Alert", "You have been alerted", "OK");
                }
            }
            catch(Exception ex)
            {
                Debug.Print($"Error: ", ex.Message);
            }
            
            Console.WriteLine("btnLogin pressed!");
        }

        private void cmd_Cancel()
        {
            Console.WriteLine("btnCancel pressed!");
        }
    }
}

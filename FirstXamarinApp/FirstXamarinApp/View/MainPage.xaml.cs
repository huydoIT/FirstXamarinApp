using FirstXamarinApp.Model;
using FirstXamarinApp.Ultil;
using FirstXamarinApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstXamarinApp
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        ObservableCollection<Account> allList = new ObservableCollection<Account>();
        public MainPage()
        {
            InitializeComponent();
            lstPersons.ItemsSource = allList;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            foreach(var item in allPersons)
            {
                allList.Add(item);
            }
            
        }
    }
}

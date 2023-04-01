using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _curValue = 10;
        public int CurValue
        {
            get { return _curValue; }
            set { 
                _curValue = value;
                OnPropertyChanged();
            }
        }

        public ICommand CommandAdd => new Command(ValueAdd);
        public ICommand CommandMinize => new Command(ValueMinimize);

        private void ValueAdd()
        {
            CurValue++;
            Console.WriteLine("btnAdd pressed!");
        }

        private void ValueMinimize()
        {
            CurValue--;
            Console.WriteLine("btnMinimize pressed!");
        }
    }
}

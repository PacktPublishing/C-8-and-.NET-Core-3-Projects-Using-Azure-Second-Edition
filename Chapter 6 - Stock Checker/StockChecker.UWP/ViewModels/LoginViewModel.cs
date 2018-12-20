using IdentityModel.Client;
using StockChecker.UWP.Helpers;
using StockChecker.UWP.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StockChecker.UWP.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly IHttpStockClientHelper _httpStockClientHelper;

        public string Username
        {
            get => _username;
            set
            {
                UpdateField(ref _username, value);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                UpdateField(ref _password, value);
            }
        }

        public LoginViewModel(IHttpStockClientHelper httpStockClientHelper)
        {
            _httpStockClientHelper = httpStockClientHelper;

            LoginCommand = new RelayCommand(() =>
            {
                DoLogin();
            });            
        }

        private async Task DoLogin()
        {
            bool loggedIn = await _httpStockClientHelper.Login(Username, Password);
            if (loggedIn)
            {
                var frame = Window.Current.Content as Frame;
                frame.Navigate(typeof(MainPage), null);
            }
        }

        public RelayCommand LoginCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool UpdateField<T>(ref T field, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

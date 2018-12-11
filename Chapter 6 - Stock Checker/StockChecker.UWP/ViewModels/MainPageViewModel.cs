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
using System.Windows.Input;

namespace StockChecker.UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _productId;
        private int _quantity;
        private int _originalQuantity;

        public int ProductId
        {
            get => _productId;
            set
            {
                if (UpdateField(ref _productId, value))
                {
                    RefreshQuantity();
                }
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (UpdateField(ref _quantity, value))
                {
                    UpdateQuantity.RaiseCanExecuteChanged();
                }
            }
        }

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


        private readonly IHttpStockClientHelper _httpClientHelper;

        public RelayCommand UpdateQuantity { get; set; }
        
        public MainPageViewModel(IHttpStockClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;

            UpdateQuantity = new RelayCommand(async () =>
            {
                await _httpClientHelper.UpdateQuantityAsync(                    
                    ProductId, Quantity);
                await RefreshQuantity();                
            }, () => Quantity != _originalQuantity);            
        }

        private async Task RefreshQuantity()
        {
            Quantity = await _httpClientHelper.GetQuantityAsync(ProductId);
            _originalQuantity = Quantity;
            UpdateQuantity.RaiseCanExecuteChanged();
        }
    }
}

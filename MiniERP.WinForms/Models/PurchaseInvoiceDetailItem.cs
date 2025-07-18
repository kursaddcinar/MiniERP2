using System.ComponentModel;

namespace MiniERP.WinForms.Models
{
    public class PurchaseInvoiceDetailItem : INotifyPropertyChanged
    {
        private int _productID;
        private string _productCode = string.Empty;
        private string _productName = string.Empty;
        private string _unitName = string.Empty;
        private decimal _quantity = 1;
        private decimal _unitPrice;
        private decimal _vatRate = 20;
        private decimal _vatAmount;
        private decimal _lineTotal;

        public int ProductID 
        { 
            get => _productID; 
            set { _productID = value; OnPropertyChanged(); } 
        }

        public string ProductCode
        {
            get => _productCode;
            set { _productCode = value; OnPropertyChanged(); }
        }

        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(); }
        }

        public string UnitName
        {
            get => _unitName;
            set { _unitName = value; OnPropertyChanged(); }
        }

        public decimal Quantity 
        { 
            get => _quantity; 
            set { _quantity = value; OnPropertyChanged(); } 
        }

        public decimal UnitPrice 
        { 
            get => _unitPrice; 
            set { _unitPrice = value; OnPropertyChanged(); } 
        }

        public decimal VatRate 
        { 
            get => _vatRate; 
            set { _vatRate = value; OnPropertyChanged(); } 
        }

        public decimal VatAmount 
        { 
            get => _vatAmount; 
            set { _vatAmount = value; OnPropertyChanged(); } 
        }

        public decimal LineTotal 
        { 
            get => _lineTotal; 
            set { _lineTotal = value; OnPropertyChanged(); } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}



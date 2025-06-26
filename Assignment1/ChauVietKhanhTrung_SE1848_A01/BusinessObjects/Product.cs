using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Product : INotifyPropertyChanged
    {
        private int _productID;
        private string _productName;
        private int? _categoryID;
        private decimal? _unitPrice;
        private int? _unitsInStock;
        private string? _quantityPerUnit;

        public int ProductID
        {
            get => _productID;
            set { if (_productID != value) { _productID = value; OnPropertyChanged(nameof(ProductID)); } }
        }
        public string ProductName
        {
            get => _productName;
            set { if (_productName != value) { _productName = value; OnPropertyChanged(nameof(ProductName)); } }
        }
        public int? CategoryID
        {
            get => _categoryID;
            set { if (_categoryID != value) { _categoryID = value; OnPropertyChanged(nameof(CategoryID)); } }
        }
        public decimal? UnitPrice
        {
            get => _unitPrice;
            set { if (_unitPrice != value) { _unitPrice = value; OnPropertyChanged(nameof(UnitPrice)); } }
        }
        public int? UnitsInStock
        {
            get => _unitsInStock;
            set { if (_unitsInStock != value) { _unitsInStock = value; OnPropertyChanged(nameof(UnitsInStock)); } }
        }
        public string? QuantityPerUnit
        {
            get => _quantityPerUnit;
            set { if (_quantityPerUnit != value) { _quantityPerUnit = value; OnPropertyChanged(nameof(QuantityPerUnit)); } }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

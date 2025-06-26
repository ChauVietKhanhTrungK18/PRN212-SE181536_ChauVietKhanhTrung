using BusinessLayer.IService;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChauVietKhanhTrungWPF.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private Product _newProduct;
        public Product NewProduct
        {
            get { return _newProduct; }
            set
            {
                _newProduct = value;
                OnPropertyChanged(nameof(NewProduct));
            }
        }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            _newProduct = new Product(); 
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            Products = new ObservableCollection<Product>(products);
        }

        public void AddProduct()
        {
            if (NewProduct != null)
            {
                _productService.AddProduct(NewProduct);
                LoadProducts(); 
            }
        }
        public void UpdateProduct()
        {
            if (SelectedProduct != null)
            {
                _productService.UpdateProduct(SelectedProduct.ProductID, SelectedProduct);
                LoadProducts(); 
            }
        }

        public void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                _productService.DeleteProduct(SelectedProduct.ProductID);
                LoadProducts(); 
            }
        }

        public void SearchProductByName(string name)
        {
            var result = _productService.SearchProductByName(name);
            Products = new ObservableCollection<Product>(result);
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

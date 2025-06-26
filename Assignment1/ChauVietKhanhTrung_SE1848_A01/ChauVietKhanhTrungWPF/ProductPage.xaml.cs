using BusinessLayer.IService;
using BusinessLayer.Service;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChauVietKhanhTrungWPF
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Employee _employee;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IEmployeeService _employeeService;
        private ObservableCollection<Product> _dataGridProducts;
        private Product _selectedProduct;
        private CollectionViewSource _productViewSource;

        public ProductPage(ICustomerService customerService, IProductService productService, IOrderService orderService, Employee employee, IOrderDetailService orderDetailService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _employee = employee;
            _employeeService = employeeService;
            _orderDetailService = orderDetailService;
            _dataGridProducts = new ObservableCollection<Product>(_productService.GetAllProducts());
            _productViewSource = new CollectionViewSource { Source = _dataGridProducts };
            ProductDataGrid.ItemsSource = _productViewSource.View;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = SearchTextBox.Text.ToLower();
            _productViewSource.View.Filter = obj =>
            {
                var p = obj as Product;
                return p.ProductName != null && p.ProductName.ToLower().Contains(searchTerm);
            };
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            _selectedProduct = null;
            ProductNameTextBox.Clear();
            CategoryIDTextBox.Clear();
            UnitPriceTextBox.Clear();
            UnitsInStockTextBox.Clear();
            QuantityPerUnitTextBox.Clear();
            ProductPopup.IsOpen = true;
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                _selectedProduct = selectedProduct;
                ProductNameTextBox.Text = _selectedProduct.ProductName;
                CategoryIDTextBox.Text = _selectedProduct.CategoryID?.ToString();
                UnitPriceTextBox.Text = _selectedProduct.UnitPrice?.ToString();
                UnitsInStockTextBox.Text = _selectedProduct.UnitsInStock?.ToString();
                QuantityPerUnitTextBox.Text = _selectedProduct.QuantityPerUnit;
                ProductPopup.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductDataGrid.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _productService.DeleteProduct(selectedProduct.ProductID);
                    _dataGridProducts.Remove(selectedProduct);
                    MessageBox.Show("Product deleted successfully.");
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text)
                || string.IsNullOrWhiteSpace(CategoryIDTextBox.Text)
                || string.IsNullOrWhiteSpace(UnitPriceTextBox.Text)
                || string.IsNullOrWhiteSpace(UnitsInStockTextBox.Text)
                || string.IsNullOrWhiteSpace(QuantityPerUnitTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning");
                return;
            }

            int.TryParse(CategoryIDTextBox.Text, out int categoryId);
            decimal.TryParse(UnitPriceTextBox.Text, out decimal unitPrice);
            int.TryParse(UnitsInStockTextBox.Text, out int unitsInStock);

            if (_selectedProduct == null)
            {
                var newProduct = new Product
                {
                    ProductID = _dataGridProducts.Count > 0 ? _dataGridProducts.Max(p => p.ProductID) + 1 : 1,
                    ProductName = ProductNameTextBox.Text,
                    CategoryID = categoryId,
                    UnitPrice = unitPrice,
                    UnitsInStock = unitsInStock,
                    QuantityPerUnit = QuantityPerUnitTextBox.Text
                };
                _productService.AddProduct(newProduct);
                _dataGridProducts.Add(newProduct);
                MessageBox.Show("Product added successfully.");
            }
            else
            {
                _selectedProduct.ProductName = ProductNameTextBox.Text;
                _selectedProduct.CategoryID = categoryId;
                _selectedProduct.UnitPrice = unitPrice;
                _selectedProduct.UnitsInStock = unitsInStock;
                _selectedProduct.QuantityPerUnit = QuantityPerUnitTextBox.Text;

                _productService.UpdateProduct(_selectedProduct.ProductID, _selectedProduct);
                ProductDataGrid.Items.Refresh();
                MessageBox.Show("Product updated successfully.");
            }

            ProductPopup.IsOpen = false;
            _selectedProduct = null;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ProductPopup.IsOpen = false;
        }

        private void BackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_customerService, _productService, _orderService, _employee, _orderDetailService,_employeeService);
            adminWindow.Show();
            this.Close();
        }
    }
}

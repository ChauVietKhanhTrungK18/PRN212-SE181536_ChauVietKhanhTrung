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
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Employee _employee;
        private readonly IOrderDetailService _orderDetailService;
        private CollectionViewSource _customerViewSource;
        private Customer _selectedCustomer;
        private ObservableCollection<Customer> _dataGridCustomers;
        private readonly IEmployeeService _employeeService;

        public CustomerPage(ICustomerService customerService, IProductService productService, IOrderService orderService, Employee employee, IOrderDetailService orderDetailService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _employee = employee;
            _orderDetailService = orderDetailService;
            _dataGridCustomers = _customerService.GetAllCustomers();
            _employeeService = employeeService;
            _customerViewSource = new CollectionViewSource { Source = _dataGridCustomers };
            CustomerDataGrid.ItemsSource = _customerViewSource.View;
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchTerm = SearchTextBox.Text.ToLower();
            _customerViewSource.View.Filter = obj =>
            {
                var c = obj as Customer;
                return c.ContactName != null && c.ContactName.ToLower().Contains(searchTerm);
            };
        }
        private bool ValidateCustomerInput()
        {
            if (string.IsNullOrWhiteSpace(CompanyNameTextBox.Text)
                || string.IsNullOrWhiteSpace(ContactNameTextBox.Text)
                || string.IsNullOrWhiteSpace(AddressTextBox.Text)
                || string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning");
                return false;
            }
            return true;
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            _selectedCustomer = null;
            CompanyNameTextBox.Clear();
            ContactNameTextBox.Clear();
            ContactTitleTextBox.Clear();
            AddressTextBox.Clear();
            PhoneTextBox.Clear();

            CustomerPopup.IsOpen = true;
        }

        private void EditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                _selectedCustomer = selectedCustomer;
                CompanyNameTextBox.Text = _selectedCustomer.CompanyName;
                ContactNameTextBox.Text = _selectedCustomer.ContactName;
                ContactTitleTextBox.Text = _selectedCustomer.ContactTitle;
                AddressTextBox.Text = _selectedCustomer.Address;
                PhoneTextBox.Text = _selectedCustomer.Phone;

                CustomerPopup.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateCustomerInput()) return;
            var newCustomer = new Customer
            {
                CompanyName = CompanyNameTextBox.Text,
                ContactName = ContactNameTextBox.Text,
                ContactTitle = ContactTitleTextBox.Text,
                Address = AddressTextBox.Text,
                Phone = PhoneTextBox.Text
            };

            bool result;

            if (_selectedCustomer == null) // Nếu là thêm mới
            {
                newCustomer.CustomerID = _customerService.GetAllCustomers().Max(c => c.CustomerID) + 1;
                result = _customerService.AddCustomer(newCustomer);
                if (result)
                {
                    MessageBox.Show("Customer added successfully.");
                }
                else
                {
                    MessageBox.Show("Customer already exists.");
                }
            }
            else // Nếu là chỉnh sửa
            {
                _selectedCustomer.CompanyName = CompanyNameTextBox.Text;
                _selectedCustomer.ContactName = ContactNameTextBox.Text;
                _selectedCustomer.ContactTitle = ContactTitleTextBox.Text;
                _selectedCustomer.Address = AddressTextBox.Text;
                _selectedCustomer.Phone = PhoneTextBox.Text;
                _selectedCustomer.NotifyAll();
                MessageBox.Show("Customer updated successfully.");
                result = true;
            }

            if (result)
            {
                //RefreshCustomerData();
                CustomerPopup.IsOpen = false;  
            }
            _selectedCustomer = null;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CustomerPopup.IsOpen = false; 
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool deleteResult = _customerService.DeleteCustomer(selectedCustomer.CustomerID);
                    if (deleteResult)
                    {
                        MessageBox.Show("Customer deleted successfully.");
                        //RefreshCustomerData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void BackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_customerService, _productService, _orderService, _employee,_orderDetailService,_employeeService);
            adminWindow.Show();
            this.Close();
        }
    }
}

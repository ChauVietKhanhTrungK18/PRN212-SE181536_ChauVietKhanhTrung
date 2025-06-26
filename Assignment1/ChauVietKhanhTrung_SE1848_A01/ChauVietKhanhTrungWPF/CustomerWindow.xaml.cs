using BusinessLayer.IService;
using BusinessObjects;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IEmployeeService _employeeService;
        private readonly Customer _customer;

        public CustomerWindow(ICustomerService customerService, IOrderService orderService, IOrderDetailService orderDetailService, IEmployeeService employeeService, Customer customer)
        {
            InitializeComponent();
            _customerService = customerService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _employeeService = employeeService;
            _customer = customer;
            LoadCustomerOrders();
        }

        private void LoadCustomerOrders()
        {
            var customerOrders = _orderService.GetAllOrders().Where(o => o.CustomerID == _customer.CustomerID).ToList();
            foreach (var order in customerOrders)
            {
                order.OrderDetails = _orderDetailService.GetOrderDetailsByOrderID(order.OrderID);
            }
            OrderDataGrid.ItemsSource = customerOrders;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadCustomerOrders();
                return;
            }

            var customerOrders = _orderService.GetAllOrders().Where(o => o.CustomerID == _customer.CustomerID &&
                                                (o.OrderID.ToString().Contains(searchText) || o.CustomerID.ToString().Contains(searchText))).ToList();

            foreach (var order in customerOrders)
            {
                order.OrderDetails = _orderDetailService.GetOrderDetailsByOrderID(order.OrderID);
            }
            OrderDataGrid.ItemsSource = customerOrders;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginPage(); 
            loginWindow.Show();
            this.Close(); 
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            PhoneTextBox.Text = _customer.Phone;
            CompanyNameTextBox.Text = _customer.CompanyName;
            ContactNameTextBox.Text = _customer.ContactName;
            ContactTitleTextBox.Text = _customer.ContactTitle;
            AddressTextBox.Text = _customer.Address;
            ProfilePopup.IsOpen = true;
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e)
        {
            var phone = PhoneTextBox.Text;
            var companyName = CompanyNameTextBox.Text;
            var contactName = ContactNameTextBox.Text;
            var contactTitle = ContactTitleTextBox.Text;
            var address = AddressTextBox.Text;
            if (string.IsNullOrEmpty(phone) || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Phone number must be numeric.");
                return;
            }
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            var customer = _customer;

            if (customer != null)
            {
                customer.CompanyName = companyName;
                customer.ContactName = contactName;
                customer.ContactTitle = contactTitle;
                customer.Address = address;
                customer.Phone = phone;

                _customerService.UpdateCustomer(customer.CustomerID,customer);

                ProfilePopup.IsOpen = false;
                MessageBox.Show("Profile updated successfully.");
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }

        private void CancelProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfilePopup.IsOpen = false;
        }
    }
}

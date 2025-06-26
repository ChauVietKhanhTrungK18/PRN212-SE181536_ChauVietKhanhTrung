using BusinessLayer.IService;
using BusinessLayer.Service;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        public LoginPage()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _customerService = new CustomerService();
            _productService = new ProductService();
            _orderService = new OrderService();
            _orderDetailService = new OrderDetailService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string userName = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string phone = PhoneTextBox.Text;

            // Xác thực Employee (Admin)
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                if (_employeeService.AuthenticateEmployee(userName, password))
                {
                    var employee = _employeeService.GetEmployeeByUserName(userName);
                    var mainWindow = new AdminWindow(_customerService, _productService, _orderService, employee, _orderDetailService,_employeeService);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid credentials for Employee");
                }
            }
            // Xác thực Customer (Customer login by phone)
            else if (!string.IsNullOrEmpty(phone))
            {
                if (_customerService.AuthenticateCustomer(phone))
                {
                        var customer = _customerService.GetCustomerByPhone(phone);
                        var customerMainWindow = new CustomerWindow(
                            _customerService,
                            _orderService,
                            _orderDetailService,
                            _employeeService,
                            customer); 
                    customerMainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid phone number");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid login details");
            }
        }
    }
}

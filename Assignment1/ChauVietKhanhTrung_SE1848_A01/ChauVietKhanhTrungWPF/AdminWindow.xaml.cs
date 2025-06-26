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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Employee _employee;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IEmployeeService _employeeService;


        public AdminWindow(ICustomerService customerService, IProductService productService, IOrderService orderService, Employee employee,IOrderDetailService orderDetailService , IEmployeeService employeeService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _employee = employee;
            _orderDetailService = orderDetailService;
            _employeeService = employeeService;
            LoadDashboard();
        }
        private void LoadDashboard()
        {
            var totalCustomers = _customerService.GetAllCustomers().Count;
            var totalProducts = _productService.GetAllProducts().Count;
            var totalOrders = _orderService.GetAllOrders().Count;

            TotalCustomersTextBlock.Text = $"{totalCustomers}";
            TotalProductsTextBlock.Text = $"{totalProducts}";
            TotalOrdersTextBlock.Text = $"{totalOrders}";
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e)
        {
            var customerPage = new CustomerPage(_customerService, _productService, _orderService, _employee,_orderDetailService, _employeeService); 
            customerPage.Show();
            this.Hide();  
        }

        private void ManageProducts_Click(object sender, RoutedEventArgs e)
        {
            var productPage = new ProductPage(_customerService, _productService, _orderService, _employee, _orderDetailService, _employeeService);
            productPage.Show();
            this.Hide();
        }


        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var orderPage = new OrderPage(_customerService, _productService, _orderService, _employee, _orderDetailService, _employeeService);
            orderPage.Show();
            this.Hide();
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            var reportPage = new ReportPage(_customerService, _productService, _orderService, _employee, _orderDetailService,_employeeService); 
            reportPage.Show();
            this.Hide();  
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginPage(); 
            loginWindow.Show();
            this.Close();
        }
    }
}

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
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Employee _employee;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IEmployeeService _employeeService;
        public ReportPage(ICustomerService customerService, IProductService productService, IOrderService orderService, Employee employee,IOrderDetailService orderDetailService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _customerService = customerService;
            _productService = productService;
            _orderService = orderService;
            _employee = employee;
            _orderDetailService = orderDetailService;
            FromDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
            ToDatePicker.SelectedDate = DateTime.Today;
            _employeeService = employeeService;
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (FromDatePicker.SelectedDate == null || ToDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select both dates.");
                return;
            }

            var from = FromDatePicker.SelectedDate.Value;
            var to = ToDatePicker.SelectedDate.Value;
            if (from > to)
            {
                MessageBox.Show("From date must be before To date.");
                return;
            }

            var orders = _orderService.SearchOrderByDate(from, to);
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            foreach (var order in orders)
            {
                order.OrderDetails = orderDetails
                    .Where(od => od.OrderID == order.OrderID)
                    .ToList();
            }
            OrderDataGrid.ItemsSource = orders;

            TotalOrdersText.Text = $"Total Orders: {orders.Count}";
            decimal totalRevenue = orders.Sum(o => o.OrderDetails?.Sum(od => od.UnitPrice * od.Quantity * (1 - od.Discount)) ?? 0);
            TotalRevenueText.Text = $"Total Revenue: {totalRevenue:C}";
        }
        private void BackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_customerService, _productService, _orderService, _employee, _orderDetailService,_employeeService);
            adminWindow.Show();
            this.Close();
        }
    }
}

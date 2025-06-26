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
    /// Interaction logic for OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly Employee _employee;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IEmployeeService _employeeService;

        public OrderPage(ICustomerService customerService, IProductService productService, IOrderService orderService, Employee employee, IOrderDetailService orderDetailService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _customerService = customerService;
            _employee = employee;
            _productService = productService;
            _employeeService= employeeService;
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _orderService.GetAllOrders();
            foreach (var order in orders)
            {
                order.OrderDetails = _orderDetailService.GetOrderDetailsByOrderID(order.OrderID);
            }
            OrderDataGrid.ItemsSource = orders;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadOrders();
            }
            else
            {
                var allOrders = _orderService.GetAllOrders();
                int idSearch;
                var result = int.TryParse(searchText, out idSearch)
                    ? allOrders.Where(o => o.OrderID == idSearch || o.CustomerID == idSearch).ToList()
                    : allOrders.Where(o =>
                        _customerService.GetCustomerById(o.CustomerID)?.CompanyName?.ToLower().Contains(searchText.ToLower()) == true
                    ).ToList();

                foreach (var order in result)
                {
                    order.OrderDetails = _orderDetailService.GetOrderDetailsByOrderID(order.OrderID);
                }
                OrderDataGrid.ItemsSource = result;
            }
        }

        private void BackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_customerService, _productService, _orderService, _employee, _orderDetailService, _employeeService);
            adminWindow.Show();
            this.Close();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearOrderPopup();
            OrderPopup.IsOpen = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CustomerIDTextBox.Text, out int customerId) ||
                _customerService.GetCustomerById(customerId) == null)
            {
                MessageBox.Show("Invalid Customer ID.");
                return;
            }
            if (!int.TryParse(EmployeeIDTextBox.Text, out int employeeId) ||
                _employeeService.GetEmployeeById(employeeId) == null)
            {
                MessageBox.Show("Invalid Employee ID.");
                return;
            }
            if (OrderDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select order date.");
                return;
            }

            var newOrder = new Order
            {
                OrderID = GetNextOrderID(), 
                CustomerID = customerId,
                EmployeeID = employeeId,
                OrderDate = OrderDatePicker.SelectedDate.Value
            };
            _orderService.AddOrder(newOrder);

            var detailDialog = new OrderDetailDialog(_productService, _orderDetailService, newOrder.OrderID);
            detailDialog.Owner = this;
            detailDialog.ShowDialog();

            LoadOrders();
            OrderPopup.IsOpen = false;
        }

        private void ClearOrderPopup()
        {
            CustomerIDTextBox.Text = "";
            EmployeeIDTextBox.Text = "";
            OrderDatePicker.SelectedDate = DateTime.Today;
        }

        private int GetNextOrderID()
        {
            var allOrders = _orderService.GetAllOrders();
            return allOrders.Count == 0 ? 1 : allOrders.Max(o => o.OrderID) + 1;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OrderPopup.IsOpen = false;
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var order = OrderDataGrid.SelectedItem as Order;
            if (order == null)
            {
                MessageBox.Show("Select an order to delete!");
                return;
            }

            var confirm = MessageBox.Show($"Delete order {order.OrderID} and all details?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (confirm == MessageBoxResult.Yes)
            {
                _orderService.DeleteOrder(order.OrderID);
                LoadOrders();
            }
        }

    }
}

using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class OrderDAO
    {
        private ObservableCollection<Order> _orders;
        public OrderDAO()
        {
            _orders = new ObservableCollection<Order>
            {
                new Order { OrderID = 1, CustomerID = 1, EmployeeID = 1, OrderDate = DateTime.Now.AddDays(-1) },
                new Order { OrderID = 2, CustomerID = 1, EmployeeID = 2, OrderDate = DateTime.Now.AddDays(-2) }, 
                new Order { OrderID = 3, CustomerID = 2, EmployeeID = 3, OrderDate = DateTime.Now.AddDays(-3) },
                new Order { OrderID = 4, CustomerID = 2, EmployeeID = 4, OrderDate = DateTime.Now.AddDays(-4) },
                new Order { OrderID = 5, CustomerID = 3, EmployeeID = 5, OrderDate = DateTime.Now.AddDays(-5) },
                new Order { OrderID = 6, CustomerID = 4, EmployeeID = 6, OrderDate = DateTime.Now.AddDays(-6) },
                new Order { OrderID = 7, CustomerID = 4, EmployeeID = 7, OrderDate = DateTime.Now.AddDays(-7) }, 
                new Order { OrderID = 8, CustomerID = 5, EmployeeID = 8, OrderDate = DateTime.Now.AddDays(-8) },
                new Order { OrderID = 9, CustomerID = 5, EmployeeID = 9, OrderDate = DateTime.Now.AddDays(-9) }, 
                new Order { OrderID = 10, CustomerID = 6, EmployeeID = 10, OrderDate = DateTime.Now.AddDays(-10) }
            };
        }
        public void AddOrder(Order order) => _orders.Add(order);
        public ObservableCollection<Order> GetAllOrders() => _orders;
        public Order GetOrderById(int orderId) => _orders.FirstOrDefault(o => o.OrderID == orderId);
        public void UpdateOrder(Order updatedOrder)
        {
            var order = _orders.FirstOrDefault(o => o.OrderID == updatedOrder.OrderID);
            if (order != null)
            {
                // Cập nhật toàn bộ thông tin của đơn hàng
                order.CustomerID = updatedOrder.CustomerID;
                order.EmployeeID = updatedOrder.EmployeeID;
                order.OrderDate = updatedOrder.OrderDate;
                order.OrderDetails = updatedOrder.OrderDetails; 
            }
        }
        public void DeleteOrder(int orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null) _orders.Remove(order);
        }
        public List<Order> SearchOrderByDate(DateTime startDate, DateTime endDate) =>
            _orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).OrderByDescending(o => o.OrderDate).ToList();
    }
}


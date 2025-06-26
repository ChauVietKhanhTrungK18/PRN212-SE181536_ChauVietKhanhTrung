using BusinessObjects;
using DataAccessLayer.DAO;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _orderDAO;
        public OrderRepository()
        {
            _orderDAO = new OrderDAO();
        }
        public void AddOrder(Order order)
        {
            _orderDAO.AddOrder(order);
        }
        public ObservableCollection<Order> GetAllOrders()
        {
            return _orderDAO.GetAllOrders();
        }
        public Order GetOrderById(int orderId)
        {
            return _orderDAO.GetOrderById(orderId);
        }
        public void UpdateOrder(Order updatedOrder)
        {
            _orderDAO.UpdateOrder(updatedOrder);
        }
        public void DeleteOrder(int orderId)
        {
            _orderDAO.DeleteOrder(orderId);
        }
        public List<Order> SearchOrderByDate(DateTime startDate, DateTime endDate)
        {
            return _orderDAO.SearchOrderByDate(startDate, endDate);
        }
    }

}

using BusinessLayer.IService;
using BusinessObjects;
using DataAccessLayer.DAO;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _orderDetailRepository = new OrderDetailRepository();
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public ObservableCollection<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            _orderRepository.UpdateOrder(updatedOrder);
        }

        public void DeleteOrder(int orderId)
        {
            var orderDetails = _orderDetailRepository.GetOrderDetailsByOrderID(orderId);
            foreach (var orderDetail in orderDetails)
            {
                _orderDetailRepository.DeleteOrderDetail(orderId, orderDetail.ProductID); 
            }

            _orderRepository.DeleteOrder(orderId);
        }

        public List<Order> SearchOrderByDate(DateTime startDate, DateTime endDate)
        {
            return _orderRepository.SearchOrderByDate(startDate, endDate);
        }
    }

}

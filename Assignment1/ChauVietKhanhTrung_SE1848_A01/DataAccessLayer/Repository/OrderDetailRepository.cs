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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _orderDetailDAO;
        public OrderDetailRepository()
        {
            _orderDetailDAO = new OrderDetailDAO(); 
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailDAO.AddOrderDetail(orderDetail);
        }
        public ObservableCollection<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailDAO.GetAllOrderDetails();
        }
        //public OrderDetail GetOrderDetailByOrderID(int orderId)
        //{
        //    return _orderDetailDAO.GetOrderDetailByOrderID(orderId);
        //}
        public void UpdateOrderDetail(int orderId, int productId, decimal newUnitPrice, int newQuantity, decimal newDiscount)
        {
            _orderDetailDAO.UpdateOrderDetail(orderId, productId, newUnitPrice, newQuantity, newDiscount);
        }
        public void DeleteOrderDetail(int orderId, int productId)
        {
            _orderDetailDAO.DeleteOrderDetail(orderId, productId);
        }
        public List<OrderDetail> GetOrderDetailsByOrderID(int orderId)
        {
            return _orderDetailDAO.GetOrderDetailsByOrderID(orderId);
        }
    }

}

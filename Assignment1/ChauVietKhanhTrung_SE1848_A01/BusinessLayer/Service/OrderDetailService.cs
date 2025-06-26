using BusinessLayer.IService;
using BusinessObjects;
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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.AddOrderDetail(orderDetail);
        }

        public ObservableCollection<OrderDetail> GetAllOrderDetails()
        {
            return _orderDetailRepository.GetAllOrderDetails();
        }

        //public OrderDetail GetOrderDetailByOrderID(int orderId)
        //{
        //    return _orderDetailRepository.GetOrderDetailByOrderID(orderId);
        //}

        public void UpdateOrderDetail(int orderId, int productId, decimal newUnitPrice, int newQuantity, decimal newDiscount)
        {
            _orderDetailRepository.UpdateOrderDetail(orderId, productId, newUnitPrice, newQuantity, newDiscount);
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            _orderDetailRepository.DeleteOrderDetail(orderId, productId);
        }

        public List<OrderDetail> GetOrderDetailsByOrderID(int orderId)
        {
            return _orderDetailRepository.GetOrderDetailsByOrderID(orderId);
        }
    }

}

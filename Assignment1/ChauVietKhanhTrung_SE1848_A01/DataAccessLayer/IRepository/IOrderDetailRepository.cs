using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IOrderDetailRepository
    {
        void AddOrderDetail(OrderDetail orderDetail);
        ObservableCollection<OrderDetail> GetAllOrderDetails();
        //OrderDetail GetOrderDetailByOrderID(int orderId);
        void UpdateOrderDetail(int orderId, int productId, decimal newUnitPrice, int newQuantity, decimal newDiscount);
        void DeleteOrderDetail(int orderId, int productId);
        List<OrderDetail> GetOrderDetailsByOrderID(int orderId);
    }

}

using BusinessLayer.IService;
using BusinessObjects;
using System.Collections.ObjectModel;
using System.Windows;

namespace ChauVietKhanhTrungWPF
{
    public partial class OrderDetailDialog : Window
    {
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly int _orderId;
        private ObservableCollection<OrderDetail> _orderDetails = new();

        public OrderDetailDialog(IProductService productService, IOrderDetailService orderDetailService, int orderId)
        {
            InitializeComponent();
            _productService = productService;
            _orderDetailService = orderDetailService;
            _orderId = orderId;

            ProductComboBox.ItemsSource = _productService.GetAllProducts();
            OrderDetailGrid.ItemsSource = _orderDetails;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductComboBox.SelectedItem is not Product selectedProduct)
            {
                MessageBox.Show("Chọn sản phẩm!");
                return;
            }
            if (!int.TryParse(QuantityTextBox.Text, out int qty) || qty < 1)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }
            if (!decimal.TryParse(DiscountTextBox.Text, out decimal discount) || discount < 0 || discount > 1)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 1!");
                return;
            }

            var detail = new OrderDetail
            {
                OrderID = _orderId,
                ProductID = selectedProduct.ProductID,
                UnitPrice = selectedProduct.UnitPrice ?? 0,
                Quantity = qty,
                Discount = discount
            };
            _orderDetailService.AddOrderDetail(detail);
            _orderDetails.Add(detail);
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

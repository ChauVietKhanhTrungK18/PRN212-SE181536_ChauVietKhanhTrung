using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        ObservableCollection<Product> GetAllProducts();
        Product GetProductById(int productId);
        void UpdateProduct(int productId, Product newProduct);
        void DeleteProduct(int productId);
        List<Product> SearchProductByName(string name);
    }

}

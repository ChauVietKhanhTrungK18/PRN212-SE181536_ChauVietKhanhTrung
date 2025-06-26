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
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO;

        public ProductRepository()
        {
            _productDAO = new ProductDAO(); 
        }
        public void AddProduct(Product product)
        {
            _productDAO.AddProduct(product);
        }
        public ObservableCollection<Product> GetAllProducts()
        {
            return _productDAO.GetAllProducts();
        }
        public Product GetProductById(int productId)
        {
            return _productDAO.GetProductById(productId);
        }
        public void UpdateProduct(int productId, Product newProduct)
        {
            _productDAO.UpdateProduct(productId, newProduct);
        }
        public void DeleteProduct(int productId)
        {
            _productDAO.DeleteProduct(productId);
        }
        public List<Product> SearchProductByName(string name)
        {
            return _productDAO.SearchProductByName(name);
        }
    }

}

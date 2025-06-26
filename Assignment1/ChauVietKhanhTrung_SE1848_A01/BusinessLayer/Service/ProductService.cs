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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }


        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProductById(productId);
        }

        public void UpdateProduct(int productId, Product newProduct)
        {
            _productRepository.UpdateProduct(productId, newProduct);
        }

        public void DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public List<Product> SearchProductByName(string name)
        {
            return _productRepository.SearchProductByName(name);
        }
    }

}

using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class ProductDAO
    {
        private ObservableCollection<Product> _products;
        public ProductDAO()
        {
            _products = new ObservableCollection<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", CategoryID = 1, UnitPrice = 18.00m, UnitsInStock = 39, QuantityPerUnit = "10 boxes x 20 bags" },
            new Product { ProductID = 2, ProductName = "Chang", CategoryID = 1, UnitPrice = 19.00m, UnitsInStock = 17, QuantityPerUnit = "24 - 12 oz bottles" },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", CategoryID = 2, UnitPrice = 10.00m, UnitsInStock = 13, QuantityPerUnit = "12 - 550 ml bottles" },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", CategoryID = 2, UnitPrice = 22.00m, UnitsInStock = 53, QuantityPerUnit = "48 - 6 oz jars" },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", CategoryID = 2, UnitPrice = 21.35m, UnitsInStock = 0, QuantityPerUnit = "36 boxes" },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", CategoryID = 2, UnitPrice = 25.00m, UnitsInStock = 120, QuantityPerUnit = "12 - 8 oz jars" },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", CategoryID = 7, UnitPrice = 30.00m, UnitsInStock = 15, QuantityPerUnit = "12 - 1 lb pkgs." },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", CategoryID = 2, UnitPrice = 40.00m, UnitsInStock = 6, QuantityPerUnit = "12 - 12 oz jars" },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", CategoryID = 6, UnitPrice = 97.00m, UnitsInStock = 29, QuantityPerUnit = "18 - 500 g pkgs." },
            new Product { ProductID = 10, ProductName = "Ikura", CategoryID = 8, UnitPrice = 31.00m, UnitsInStock = 31, QuantityPerUnit = "12 - 200 ml jars" },
            new Product { ProductID = 11, ProductName = "Queso Cabrales", CategoryID = 4, UnitPrice = 21.00m, UnitsInStock = 22, QuantityPerUnit = "1 kg pkg." },
            new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", CategoryID = 4, UnitPrice = 38.00m, UnitsInStock = 86, QuantityPerUnit = "10 - 500 g pkgs." },
            new Product { ProductID = 13, ProductName = "Konbu", CategoryID = 8, UnitPrice = 6.00m, UnitsInStock = 24, QuantityPerUnit = "2 kg box" },
            new Product { ProductID = 14, ProductName = "Tofu", CategoryID = 7, UnitPrice = 23.25m, UnitsInStock = 35, QuantityPerUnit = "40 - 100 g pkgs." },
            new Product { ProductID = 15, ProductName = "Genen Shouyu", CategoryID = 2, UnitPrice = 15.50m, UnitsInStock = 39, QuantityPerUnit = "24 - 250 ml bottles" },
            new Product { ProductID = 16, ProductName = "Pavlova", CategoryID = 3, UnitPrice = 17.45m, UnitsInStock = 29, QuantityPerUnit = "32 - 500 g boxes" },
            new Product { ProductID = 17, ProductName = "Alice Mutton", CategoryID = 6, UnitPrice = 39.00m, UnitsInStock = 0, QuantityPerUnit = "20 - 1 kg tins" },
            new Product { ProductID = 18, ProductName = "Carnarvon Tigers", CategoryID = 8, UnitPrice = 62.50m, UnitsInStock = 42, QuantityPerUnit = "16 kg pkg." },
            new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", CategoryID = 3, UnitPrice = 9.20m, UnitsInStock = 25, QuantityPerUnit = "10 boxes x 12 pieces" },
            new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", CategoryID = 3, UnitPrice = 81.00m, UnitsInStock = 40, QuantityPerUnit = "30 gift boxes" },
            new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", CategoryID = 3, UnitPrice = 10.00m, UnitsInStock = 3, QuantityPerUnit = "24 pkgs. x 4 pieces" },
            new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", CategoryID = 5, UnitPrice = 21.00m, UnitsInStock = 104, QuantityPerUnit = "24 - 500 g pkgs." },
            new Product { ProductID = 23, ProductName = "Tunnbröd", CategoryID = 5, UnitPrice = 9.00m, UnitsInStock = 61, QuantityPerUnit = "12 - 250 g pkgs." },
            new Product { ProductID = 24, ProductName = "Guaraná Fantástica", CategoryID = 1, UnitPrice = 4.50m, UnitsInStock = 20, QuantityPerUnit = "12 - 355 ml cans" },
            new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", CategoryID = 3, UnitPrice = 14.00m, UnitsInStock = 76, QuantityPerUnit = "20 - 450 g glasses" }
        };
        }

        public bool AddProduct(Product product)
        {
            if (_products.Any(p => p.ProductID == product.ProductID)) return false;
            _products.Add(product); return true;
        }
        public ObservableCollection<Product> GetAllProducts() => _products;
        public Product GetProductById(int productId) => _products.FirstOrDefault(p => p.ProductID == productId);
        public bool UpdateProduct(int productId, Product updatedProduct)
        {
            var prod = _products.FirstOrDefault(p => p.ProductID == productId);
            if (prod == null) return false;
            prod.ProductName = updatedProduct.ProductName;
            prod.CategoryID = updatedProduct.CategoryID;
            prod.UnitPrice = updatedProduct.UnitPrice;
            prod.UnitsInStock = updatedProduct.UnitsInStock;
            prod.QuantityPerUnit = updatedProduct.QuantityPerUnit;
            return true;
        }
        public void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) _products.Remove(product);
        }
        public List<Product> SearchProductByName(string name) =>
            _products.Where(p => p.ProductName.Contains(name)).ToList();
    }

}

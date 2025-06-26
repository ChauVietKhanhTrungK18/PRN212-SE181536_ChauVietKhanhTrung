using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class CategoryDAO
    {
        private List<Category> _categories;

        public CategoryDAO()
        {
            _categories = new List<Category>
            {
                new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
                new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
                new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
                new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
                new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
                new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
                new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
                new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
            };
        }
        public void AddCategory(Category category) => _categories.Add(category);
        public List<Category> GetAllCategories() => _categories;
        public Category GetCategoryById(int categoryId) => _categories.FirstOrDefault(c => c.CategoryID == categoryId);
        public void UpdateCategory(int categoryId, string newCategoryName)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (category != null) category.CategoryName = newCategoryName;
        }
        public void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (category != null) _categories.Remove(category);
        }
        public List<Category> SearchCategoryByName(string name) =>
            _categories.Where(c => c.CategoryName.Contains(name)).ToList();
    }
}


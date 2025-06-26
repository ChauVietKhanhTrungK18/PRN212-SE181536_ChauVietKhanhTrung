using BusinessObjects;
using DataAccessLayer.DAO;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryRepository()
        {
            _categoryDAO = new CategoryDAO(); 
        }
        public void AddCategory(Category category)
        {
            _categoryDAO.AddCategory(category);
        }
        public List<Category> GetAllCategories()
        {
            return _categoryDAO.GetAllCategories();
        }
        public Category GetCategoryById(int categoryId)
        {
            return _categoryDAO.GetCategoryById(categoryId);
        }
        public void UpdateCategory(int categoryId, string newCategoryName)
        {
            _categoryDAO.UpdateCategory(categoryId, newCategoryName);
        }
        public void DeleteCategory(int categoryId)
        {
            _categoryDAO.DeleteCategory(categoryId);
        }
        public List<Category> SearchCategoryByName(string name)
        {
            return _categoryDAO.SearchCategoryByName(name);
        }
    }

}

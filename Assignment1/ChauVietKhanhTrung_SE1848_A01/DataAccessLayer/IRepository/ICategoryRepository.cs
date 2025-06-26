using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        void UpdateCategory(int categoryId, string newCategoryName);
        void DeleteCategory(int categoryId);
        List<Category> SearchCategoryByName(string name);
    }

}

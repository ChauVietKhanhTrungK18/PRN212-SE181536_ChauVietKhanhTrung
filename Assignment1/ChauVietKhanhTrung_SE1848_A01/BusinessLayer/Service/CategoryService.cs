using BusinessLayer.IService;
using BusinessObjects;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        //public CategoryService(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();   
        }
        public void AddCategory(Category category)
        {
            _categoryRepository.AddCategory(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId);
        }

        public void UpdateCategory(int categoryId, string newCategoryName)
        {
            _categoryRepository.UpdateCategory(categoryId, newCategoryName);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
        }

        public List<Category> SearchCategoryByName(string name)
        {
            return _categoryRepository.SearchCategoryByName(name);
        }
    }

}

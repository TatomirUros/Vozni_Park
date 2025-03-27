using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryService _subcategoryService;
        public CategoryService() 
        {
            _categoryRepository = new CategoryRepository();
            _subcategoryService = new SubcategoryService();
        }
        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<string> GetCategoryNameById(int id)
        {
            return await _categoryRepository.GetCategoryNameByIdAsync(id);
        }
        public async Task InsertCategory(string name)
        {
            await _categoryRepository.InsertCategoryAsync(name);
        }
        public async Task UpdateCategory(int id, string name)
        {
            await _categoryRepository.UpdateCategoryAsync(id, name);
        }
        public async Task DeleteCategory(int id)
        {
            List<SubcategoryDTO> subcategories = await _subcategoryService.GetAllSubcategoriesByCategoryId(id);
            foreach (SubcategoryDTO subcategory in subcategories)
            {
                await _subcategoryService.DeleteSubcategory(subcategory.Id);
            }
            await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}

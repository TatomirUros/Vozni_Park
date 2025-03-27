using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<List<SubcategoryDTO>> GetAllSubcategoriesAsync();
        Task<string> GetSubcategoryNameByIdAsync(int id);
        Task InsertSubcategoryAsync(string name, int categoryId);
        Task UpdateSubcategoryAsync(int id, string name, int categoryId);
        Task DeleteSubcategoryAsync(int id);
        Task<List<int>> GetAllVehicleForSubcategoryAsync(int id);
        Task<List<SubcategoryDTO>> GetAllSubcategoriesByCategoryIdAsync(int categoryId);
        Task<int> GetCategoryIdBySubcategoryIdAsync(int subcategoryId);
    }
}

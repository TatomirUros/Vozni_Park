using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface ISubcategoryService
    {
        Task<List<SubcategoryDTO>> GetAllSubcategories();
        Task InsertSubcategory(string name, int categoryId);
        Task UpdateSubcategory(int id, string name, int categoryId);
        Task DeleteSubcategory(int id);
        Task<List<SubcategoryDTO>> GetAllSubcategoriesByCategoryId(int categoryId);
        Task<int> GetCategoryIdBySubcategoryId(int subcategoryId);

    }
}

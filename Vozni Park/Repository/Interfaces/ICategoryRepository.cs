using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    internal interface ICategoryRepository
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<string> GetCategoryNameByIdAsync(int id);
        Task InsertCategoryAsync(string name);
        Task UpdateCategoryAsync(int id, string name);
        Task DeleteCategoryAsync(int id);
    }
}

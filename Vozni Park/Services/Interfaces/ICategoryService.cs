using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public  interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategories();
        Task InsertCategory(string name);
        Task UpdateCategory(int id, string name);
        Task DeleteCategory(int id);
    }
}

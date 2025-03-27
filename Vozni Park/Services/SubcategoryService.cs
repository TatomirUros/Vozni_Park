using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.View;

namespace Vozni_Park.Services
{
    internal class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IVehicleRepository _vehicleRepository;
        public SubcategoryService()
        {
            _subcategoryRepository = new SubcategoryRepository();
            _vehicleRepository = new VehicleRepository();
        }
        public async Task<List<SubcategoryDTO>> GetAllSubcategories()
        {
            return await _subcategoryRepository.GetAllSubcategoriesAsync();
        }

        public async Task<string> GetSubcategoryNameById(int id)
        {
            return await _subcategoryRepository.GetSubcategoryNameByIdAsync(id);
        }
        public async Task InsertSubcategory(string name, int categoryId)
        {
            await _subcategoryRepository.InsertSubcategoryAsync(name, categoryId);
        }
        public async Task UpdateSubcategory(int id, string name, int categoryId)
        {
            await _subcategoryRepository.UpdateSubcategoryAsync(id, name, categoryId);
        }

        public async Task<List<SubcategoryDTO>> GetAllSubcategoriesByCategoryId(int categoryId)
        {
            return await _subcategoryRepository.GetAllSubcategoriesByCategoryIdAsync(categoryId);
        }

        public async Task<int> GetCategoryIdBySubcategoryId(int subcategoryId)
        {
            return await _subcategoryRepository.GetCategoryIdBySubcategoryIdAsync(subcategoryId);
        }
        public async Task DeleteSubcategory(int subcategoryId)
        {
            List<int> idVehicles = await _subcategoryRepository.GetAllVehicleForSubcategoryAsync(subcategoryId);
            foreach (int idVehicle in idVehicles)
            {
                string columnName = "idKategorije";
                await _vehicleRepository.UpdatePartVehicleAsync(idVehicle, columnName, "1");

                columnName = "idPotkategorije";
                await _vehicleRepository.UpdatePartVehicleAsync(idVehicle, columnName, "1");
            }
            await _subcategoryRepository.DeleteSubcategoryAsync(subcategoryId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class VehicleDTO
    {
        private int id;
        private string brand;
        private string model;
        private string kilometers;
        private int idOwner;
        private int idMine;
        private int idCategory;
        private int idSubcategory;
        private string registration;
        private DateOnly dateTo;
        private int idState;
        private string tireDimension;
        public VehicleDTO(int id, string brand, string model, string kilometers, int idOwner, int idMine, int idCategory, int idSubcategory, string registration, DateOnly dateTo, int idState, string tireDimension)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.kilometers = kilometers;
            this.idOwner = idOwner;
            this.idMine = idMine;
            this.idCategory = idCategory;
            this.idSubcategory = idSubcategory;
            this.registration = registration;
            this.dateTo = dateTo;
            this.idState = idState;
            this.tireDimension = tireDimension;
        }
        public VehicleDTO()
        { }

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand= value; }
        public string Model { get => model; set => model = value; }
        public string Kilometers { get => kilometers; set => kilometers = value; }
        public int IdOwner { get => idOwner; set => idOwner = value; }
        public int IdMine { get => idMine; set => idMine = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }
        public int IdSubcategory { get => idSubcategory; set => idSubcategory = value; }
        public string Registration { get => registration; set => registration = value; }
        public DateOnly DateTo { get => dateTo; set => dateTo = value; }
        public int IdState { get => idState; set => idState = value; }
        public string TireDimension { get => tireDimension; set => tireDimension = value; }

    }
}

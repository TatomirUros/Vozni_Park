using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class VehicleTableViewDTO
    {
        private int id;
        private string brand;
        private string model;
        private string kilometers;
        private string owner;
        private string mine;
        private string registration;
        private string dateTo;
        private string state;
        private string category;
        private string subcategory;
        private string tireDimension;
        public VehicleTableViewDTO(int id, string brand, string model, string kilometers, string owner, string mine, string registration, string dateTo, string state, string category, string subcategory, string tireDimension)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.kilometers = kilometers;
            this.registration = registration;
            this.dateTo = dateTo;
            this.owner = owner;
            this.mine = mine;
            this.state = state;
            this.category = category;
            this.subcategory = subcategory;
            this.tireDimension = tireDimension;
        }

        public VehicleTableViewDTO()
        { }

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Kilometers { get => kilometers; set => kilometers = value; }
        public string Registration { get => registration; set => registration = value; }
        public string DateTo { get => dateTo; set => dateTo = value; }
        public string State { get => state; set => state = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Mine { get => mine; set => mine = value; }
        public string Category{ get => category; set => category = value; }
        public string Subcategory { get => subcategory; set => subcategory = value; }
        public string TireDimension { get => tireDimension; set => tireDimension = value; }
    }
}

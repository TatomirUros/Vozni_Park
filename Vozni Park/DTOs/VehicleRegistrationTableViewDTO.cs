using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class VehicleRegistrationTableViewDTO
    {
        private int id;
        private string brand;
        private string model;
        private string owner;
        private string mine;
        private string registration;
        private string dateTo;
        private string state;

     
        public VehicleRegistrationTableViewDTO(int id, string brand, string model, string owner, string mine, string registration, string dateTo, string state)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.registration = registration;
            this.dateTo = dateTo;
            this.owner = owner;
            this.mine = mine;
            this.state = state;
        }

        public VehicleRegistrationTableViewDTO()
        { }

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Registration { get => registration; set => registration = value; }
        public string DateTo { get => dateTo; set => dateTo = value; }
        public string State { get => state; set => state = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Mine { get => mine; set => mine = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ServiceVehicleTableViewDTO
    {
        private int id;
        private string date;
        private string kilometers;
        private string nameServiceType;
        private string nameRepairer;
        private string description;
        private float price;

        public ServiceVehicleTableViewDTO(int id, string date, string kilometers, string nameServiceType, string nameRepairer, string description, float price)
        {
            this.id = id;
            this.date = date;
            this.kilometers = kilometers;     
            this.nameServiceType = nameServiceType;
            this.nameRepairer = nameRepairer;
            this.description = description;
            this.price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public string Kilometers { get => kilometers; set => kilometers = value; }
        public string NameServiceType { get => nameServiceType; set => nameServiceType = value; }
        public string NameRepairer { get => nameRepairer; set => nameRepairer = value; }
        public string Description { get => description; set => description = value; }
        public float Price { get => price; set => price = value; }


    }
}

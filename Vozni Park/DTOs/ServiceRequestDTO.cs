using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ServiceRequestDTO
    {
        private int id;
        private string name;
        private string description;
        private int idVehicle;
        private int idServiceType;

        public ServiceRequestDTO(int id, string name, string description, int idVehicle, int idServiceType)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.idVehicle = idVehicle;
            this.idServiceType = idServiceType;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
        public int IdServiceTpe { get => idServiceType; set => idServiceType = value; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class RegistrationVehicleDTO
    {
        private int id;
        private string registration;
        private int idVehicle;

        public RegistrationVehicleDTO(int id, string registration, int idVehicle)
        {
            this.id = id;
            this.registration = registration;
            this.idVehicle = idVehicle;
        }

        public int Id { get => id; set => id = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
        public string Registration { get => registration; set => registration = value; }
    }
}

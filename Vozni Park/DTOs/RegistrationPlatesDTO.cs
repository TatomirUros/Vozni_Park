using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class RegistrationPlatesDTO
    {
        private int id;
        private string registration;
        private int idVehicle;

        public RegistrationPlatesDTO(int id, string registration, int idVehicle)
        {
            this.id = id;
            this.registration = registration;
            this.idVehicle = idVehicle;
        }

        public int Id { get => id; set => id = value; }
        public string Registration { get => registration; set => registration = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
    }
}

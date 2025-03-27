using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ExecuteRequestDTO
    {
        private int id;
        private string registration;
        private string kilometers;
        private string description;
        private DateOnly date;
        private int idVehicle;
        private int idRepairer;
        private int idServiceType;
        private int idRequest;
        private float price;
        public ExecuteRequestDTO(int id, string registration, string kilometers, DateOnly date, string description, int idVehicle, int idServiceType, int idRepairer, int idRequest, float price)
        {
            this.id = id;
            this.registration = registration;
            this.kilometers = kilometers;
            this.date = date;
            this.description = description;
            this.idVehicle = idVehicle;
            this.idServiceType = idServiceType;
            this.idRepairer = idRepairer;
            this.idRequest = idRequest;
            this.price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Registration { get => registration; set => registration = value; }
        public string Kilometers { get => kilometers; set => kilometers = value; }
        public DateOnly Date{ get => date; set => date = value; }       
        public string Description { get => description; set => description = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
        public int IdServiceTpe { get => idServiceType; set => idServiceType = value; }
        public int IdRepairer { get => idRepairer; set => idRepairer = value; }
        public int IdRequest { get => idRequest; set => idRequest = value; }
        public float Price{ get => price; set => price= value; }


    }
}

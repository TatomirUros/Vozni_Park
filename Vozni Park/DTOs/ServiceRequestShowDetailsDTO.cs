using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ServiceRequestShowDetailsDTO
    {
        private int id;
        private string numberOfRequest;
        private string description;

        public ServiceRequestShowDetailsDTO(int id, string numberOfRequest, string description)
        {
            this.id = id;
            this.numberOfRequest = numberOfRequest;
            this.description = description;
        }

        public int Id { get => id; set => id = value; }
        public string NumberOfRequest { get => numberOfRequest; set => numberOfRequest = value; }
        public string Description { get => description; set => description = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ServiceRequestTableViewDTO
    {
        private int id;
        private string nameRequest;
        private string nameServiceType;

        public ServiceRequestTableViewDTO(int id, string nameRequest, string nameServiceType)
        {
            this.id = id;
            this.nameRequest = nameRequest;
            this.nameServiceType = nameServiceType;
        }

        public int Id { get => id; set => id = value; }
        public string NameRequest { get => nameRequest; set => nameRequest = value; }
        public string NameServiceType { get => nameServiceType; set => nameServiceType = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class TagDTO
    {
        private int id;
        private string registration;
        private string serialNumber;

        public TagDTO(int id, string registration, string serialNumber)
        {
            this.id = id;
            this.registration = registration;
            this.serialNumber = serialNumber;
        }

        public int Id { get => id; set => id = value; }
        public string Registration { get => registration; set => registration = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
    }
}

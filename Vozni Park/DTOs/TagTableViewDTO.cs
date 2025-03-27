using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class TagTableViewDTO
    {
        private int id;
        private string registration;
        private string serialNumber;
        private string date;
        public TagTableViewDTO(int id, string registration, string serialNumber, string date)
        {
            this.id = id;
            this.registration = registration;
            this.serialNumber = serialNumber;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public string Registration { get => registration; set => registration = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Date { get => date; set => date = value; }

    }
}

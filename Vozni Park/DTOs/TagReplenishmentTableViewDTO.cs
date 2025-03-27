using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class TagReplenishmentTableViewDTO
    {
        private int id;
        private string date;
        private float amount;

        public TagReplenishmentTableViewDTO(int id, string date, float amount)
        {
            this.id = id;
            this.date = date;
            this.amount = amount;
        }

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public float Amount { get => amount; set => amount = value; }
    }
}

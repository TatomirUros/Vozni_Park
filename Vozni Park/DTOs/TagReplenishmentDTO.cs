using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class TagReplenishmentDTO
    {
        private int id;
        private string date;
        private float amount;
        private int idTag;

        public TagReplenishmentDTO(int id, string date, float amount,int idTag)
        {
            this.id = id;
            this.date = date;
            this.amount = amount;
            this.idTag = idTag;
        }

        public int Id { get => id; set => id = value; }
        public string Date { get => date; set => date = value; }
        public float Amount { get => amount; set => amount = value; }
        public int IdTag { get => idTag; set => idTag = value; }

    }
}

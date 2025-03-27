using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class ImagesDTO
    {
        private int id;
        private Image image;

        public ImagesDTO(int id, Image name)
        {
            this.id = id;
            this.image = name;
        }

        public int Id { get => id; set => id = value; }
        public Image Image { get => image; set => image = value; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.DTOs
{
    public class CategoryDTO
    {
        private int id;
        private string name;

        public CategoryDTO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}

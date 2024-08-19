﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class Productos : ClaseBase
    {
        public Sectores Sector { get; set; }
        public string Desripcion { get; set; } 
        public int Stock { get; set; } 
        public float Precio { get; set; }


    }
}

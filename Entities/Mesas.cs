﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class Mesas : ClaseBase
    {
        public int Nombre {  get; set; }
        public EstadosMesa Estado { get; set; }
    }
}

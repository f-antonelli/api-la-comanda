﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Comandas : ClaseBase
    {
        public Comandas(int mesaId)
        {
            MesaId = mesaId;
        }

        public int MesaId { get; set; }
    }
}

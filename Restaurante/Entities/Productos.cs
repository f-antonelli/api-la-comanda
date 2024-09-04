using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Entities.Enums;

namespace Restaurante.Entities
{
    public class Productos : ClaseBase
    {
        public Productos(int stock = 0)
        {
            SetStock(stock);
        }
        public Sectores Sector { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        public float Precio { get; set; }

        private int _stock;
        public void SetStock(int stock)
        {
            int udpatedStock = this._stock + stock;
            if (udpatedStock < 0)
            {
                throw new Exception("El stock no puede ser menor a 0");
            }
            else
            {
                this._stock = udpatedStock;
            }
        }
        public int GetStock()
        {
            return this._stock;
        }
    }
}

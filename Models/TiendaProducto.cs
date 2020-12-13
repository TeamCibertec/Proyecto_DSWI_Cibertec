using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class TiendaProducto
    {
        public int ID_TIENDA_PRODUCTO  { get; set; }
        public int ID_PRODUCTO { get; set; }
        public int ID_TIENDA { get; set; }
        public int STOCK { get; set; }
        public String FECHA_LLEGADA { get; set; }
        public int STOCK_PENDIENTE { get; set; }
    }
}
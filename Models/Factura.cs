using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Factura
    {
        public int idFactura { get; set; }
        public int IGV { get; set; }
        public decimal subTotal { get; set; }
        public int dscto { get; set; }
        public decimal total { get; set; }
        public String moneda { get; set; }
        public int idOrden { get; set; }
        public int idTipoPago { get; set; }
        public int idTarjeta { get; set; }
    }
}
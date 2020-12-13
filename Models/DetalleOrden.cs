using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class DetalleOrden
    {
        public int codDetalle { get; set; }
        public int codOrden { get; set; }
        public int codProd { get; set; }
        public string desProd { get; set; }
        public int cantidad { get; set; }
        public Decimal preUnit { get; set; }
        public Decimal importe { get; set; }
        public int estDet { get; set; }
    }
}
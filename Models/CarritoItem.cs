using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class CarritoItem
    {
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public decimal preProd { get; set; }
        public int cantProd { get; set; }
        public String desProd { get; set; }
        public String imgProd { get; set; }

        public decimal subtotal()
        {
            return preProd * cantProd;
        }

    }

}
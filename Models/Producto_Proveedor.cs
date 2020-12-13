using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Producto_Proveedor
    {
        public int codProd { get; set; }
        public int codCate { get; set; }
        public int codProv { get; set; }
        
        public String desProducto { get; set; }
        public decimal preProducto { get; set; }
        public int dsctoProd { get; set; }
        public String desCate { get; set; }
        public String desProv { get; set; }
        public String imgProd { get; set; }
        public DateTime fecLlegada { get; set; }
        public int idAnime { get; set; }
        public String nomAnime { get; set; }
        public int stkProd { get; set; }
    }
}
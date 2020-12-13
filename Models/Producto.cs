using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ANIMANIA.Models
{
    public class Producto
    {
        [DisplayName("CODIGO")]
        public int codProd { get; set; }
        public int codCate { get; set; }
        public int codProv { get; set; }
        [DisplayName("DESCRIPCION")]
        public String desProducto { get; set; }
        [DisplayName("PRECIO")]
        public decimal preProducto { get; set; }
        [DisplayName("DESCUENTO")]
        public int dsctoProd { get; set; }
        [DisplayName("CATEGORIA")]
        public String desCate { get; set; }
        [DisplayName("PROVEEDOR")]
        public String desProv { get; set; }
        public int estProd { get; set; }
        public String imgProd { get; set; }
        public DateTime fecLlegada { get; set; }
        public int idAnime { get; set; }
        public String nomAnime { get; set; }
        public int stkProd { get; set; }

    }
}
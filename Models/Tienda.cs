using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Tienda
    {
        public int ID_TIENDA  { get; set; }
        public String NOMBRE_TIENDA { get; set; }
        public String DIRECCION { get; set; }
        public String PRINCIPAL_FLAG { get; set; }
    }
}
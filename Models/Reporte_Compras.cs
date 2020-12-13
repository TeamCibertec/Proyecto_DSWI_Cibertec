using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Reporte_Compras
    {
        public int idCompras { get; set; }
        public DateTime fecOrden { get; set; }
        public String nomCli { get; set; }
        public String Estado { get; set; }
    }
}
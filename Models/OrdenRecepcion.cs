using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class OrdenRecepcion
    {
        public int IdordenRecp { get; set; }

        public DateTime FechRecep { get; set; }

        public int IdOrdencompra { get; set; }

        public int Estado { get; set; }

        public int IdEmple { get; set; }

        public DateTime FechLLegadaAprox { get; set; }
    }
}
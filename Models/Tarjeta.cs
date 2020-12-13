using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Tarjeta
    {
        public int idTarjeta { get; set; }
        public String numTrx { get; set; }
        public DateTime fecVenc { get; set; }
        public String CVV { get; set; }
    }
}
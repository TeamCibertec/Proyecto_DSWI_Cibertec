using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ANIMANIA.Models
{
    public class Orden_Compra
    {
        [DisplayName("CODIGO")]
        public int codOrden { get; set; }
        public int estOrden { get; set; }
        public string estAOrdenDesc { get; set; }
        [DisplayName("CLLIENTE/PROV")]
        public string clienteProv { get; set; }
        public string codCli { get; set; }
        [DisplayName("FECHA")]
        public DateTime fecOrden { get; set; }
        [DisplayName("TIPO DE ORDEN")]
        public string flag { get; set; }
    }
}
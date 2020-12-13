using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Proveedor
    {
        public int codProv { get; set; }
        public String docIdentidad { get; set; }
        public String razSocial { get; set; }
        public String dirProv { get; set; }
        public String corProv { get; set; }
        public DateTime fecIni { get; set; }
        public DateTime fecFin { get; set; }
        public int estProv { get; set; }
        public String desEstProv { get; set; }
    }
}
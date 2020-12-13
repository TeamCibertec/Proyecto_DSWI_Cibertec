using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Empleado
    {
        public int idEmp { get; set; }
        public string docIdent { get; set; }
        public string nomEmp { get; set; }
        public string corEmp { get; set; }
        public string tipoDoc { get; set; }
        public string direcEmp { get; set; }
        public DateTime fecNac { get; set; }
        public int estEmp { get; set; }
        public DateTime fecIni { get; set; }
        public DateTime fecFin { get; set; }
        public String desEstEmp { get; set; }
    }
}
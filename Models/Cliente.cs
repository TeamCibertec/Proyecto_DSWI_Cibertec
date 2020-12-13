using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Cliente
    {
        public int idCli { get; set; }
        public String docCli { get; set; }
        public String nomCli { get; set; }
        public DateTime fecNacCli { get; set; }
        public String corCli { get; set; }
        public String telfCli { get; set; }
        public int estCli { get; set; }
        public String tipoDoc { get; set; }
        public String pswCli { get; set; }
    }
}
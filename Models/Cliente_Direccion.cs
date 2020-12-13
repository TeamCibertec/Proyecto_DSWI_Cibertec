using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Cliente_Direccion
    {
        public int idDirec { get; set; }
        public String desDirec { get; set; }
        public int idCli { get; set; }
        public int idDis { get; set; }
        public int estCliDis { get; set; }
        public String flag { get; set; }
    }
}
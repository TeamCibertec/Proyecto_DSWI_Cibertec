using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Usuario
    {
        public int idUsu { get; set; }
        public String corUsu { get; set; }
        public String passUsu { get; set; }
        public int estUsu { get; set; }
        public String desEstUsu { get; set; }
        public int idCliEmp { get; set; }
        public String nomCliEmp { get; set; }
    }
}
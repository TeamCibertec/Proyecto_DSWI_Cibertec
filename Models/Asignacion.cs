using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Asignacion
    {
        public int idAsignacion { get; set; }
        public String nomAsignacion { get; set; }
        public String nomEmpleado { get; set; }
        public int estado { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Asignacion_Empleado
    {
        public int idAsigEmp { get; set; }
        public String nomAsignacion { get; set; }
        public int estAsigEmp { get; set; }
        public String desEstAsigEmp { get; set; }
        public String nomEmpleado { get; set; }
        public int idAsignacion { get; set; }
        public int idUsuario { get; set; }
    }
}
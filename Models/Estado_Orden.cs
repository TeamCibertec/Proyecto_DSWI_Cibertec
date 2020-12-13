using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Models
{
    public class Estado_Orden
    {
        public int Estado_Pendiente { get; set; }
        public int Estado_Aprobado { get; set; }
        public int Estado_Enviado { get; set; }
        public int Estado_Cancelado { get; set; }
    }
}
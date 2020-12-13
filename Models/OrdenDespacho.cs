using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ANIMANIA.Models
{
    public class OrdenDespacho
    {
        [DisplayName("CODIGO")]
        public int codOrdDesp { get; set; }
        public int codTipo { get; set; }
        [DisplayName("MOVILIDAD")]
        public string desTipo { get; set; }
        [DisplayName("FECHA DE ENTREGA")]
        public DateTime fecEntrega { get; set; }
        [DisplayName("ESTADO")]
        public int estOrdDesp { get; set; }
        public int codEmple { get; set; }
        [DisplayName("EMPLEADO")]
        public string nomEmple { get; set; }
        public int codOrdenComp { get; set; }
    }
}
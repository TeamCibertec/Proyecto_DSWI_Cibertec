using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface Admin<T>
    {
        List<T> ListadoProductoAdmin();
        T ObtenerProductoAdmin(int cod);
        int ActualizarProductoAdmin(T prod);
        int EliminarProductoAdmin(int cod);
        int AñadirProductoAdmin(T prod);
        int ActualizarEstadoProductoAdmin(int cod,int estado);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface OrdenRecpService<T>
    {
        int registrarOrdenRecepcion(T obj);
        int ActualizarRecepcion(int cod);
    }
}

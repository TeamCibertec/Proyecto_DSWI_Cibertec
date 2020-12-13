using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface OrdenDespachoAdminService<T>
    {
        List<T> listaOrdenDespacho();

        T obtenerDespacho(int codigo);

        int insertarOrdenDespacho(T obj);

        int eliminarOrdenDespacho(int codigo);
    }
}

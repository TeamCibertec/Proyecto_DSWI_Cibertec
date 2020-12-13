using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface ClienteDireccionService<T>
    {
        List<T> listarClienteDireccion(int codCli);
        int insertarClienteDireccion(T obj);
        int actualizarClienteDireccion(int codCli);
    }
}

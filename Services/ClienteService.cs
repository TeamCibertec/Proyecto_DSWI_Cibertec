using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface ClienteService<T>
    {
        int registrarCliente(T obj);
        T buscarCliente(int cod);

        int actualizarCliente(T obj);
    }
}

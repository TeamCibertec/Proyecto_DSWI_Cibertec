using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface EmpleadoService<T>
    {
        List<T> listarEmpleadoUsuario();
        List<T> listarEmpleados();
        int registrarEmpleado(T obj);
        int actualizarContrato(T obj);
    }
}

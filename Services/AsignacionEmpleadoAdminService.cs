using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface AsignacionEmpleadoAdminService<T>
    {
        List<T> buscaAsignacionEmpleado(int codigo,String nom);

        int insertarAsignacionEmpleado(T obj);

    }
}

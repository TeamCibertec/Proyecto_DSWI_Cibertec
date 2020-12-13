using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface AsignacionAdminService<T>
    {
        List<T> listarAsigaciones();

        List<T> listarAsignaciones_x_Codigo(int codigo);

        List<T> listarAsignacionesActuales_x_Codigo(int codigo);

        int eliminarRol(int cod_asig, int cod_usu);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface UsuarioAdmin<T>
    {
        List<T> listarUsuarios();
        int insertarUsuario(T obj);
        T buscarUsuario(String cor,String pass);
        int actualizarUsuario(T obj);
    }
}

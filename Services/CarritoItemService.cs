using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface CarritoItemService<T>
    {
        List<T> listaCarritoItem();
        int eliminarCarritoItem(int prod,int usu);

        int insertarCarritoItem(T obj);

        int actualizarCarritoItem(T obj);
    }
}

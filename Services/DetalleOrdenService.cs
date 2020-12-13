using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface DetalleOrdenService<T>
    {
        int insertarDetalleOrden(T obj);
    }
}

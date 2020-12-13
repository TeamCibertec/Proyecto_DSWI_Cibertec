using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface FacturaService<T>
    {
        int insertarFactura(T obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANIMANIA.Services
{
    interface OrdenCompraAdmin<T>
    {
        List<T> listadoOrdenes();
        int updateEstadoOrden(int cod,int estado);

        int insertarOrdenCompra(T obj);
        List<T> listadoPedidoxcliente(int codigo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Services
{
    interface TiendaService<T>
    {
        List<T> listadoTiendaPorFlagPrincipal(T tie);
    }
}
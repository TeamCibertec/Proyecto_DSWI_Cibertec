﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANIMANIA.Services
{
    interface TiendaProductoService<T>
    {
        List<T> listaTiendaProducto();
        int actualizasTiendaProducto(T obj);
    }
}
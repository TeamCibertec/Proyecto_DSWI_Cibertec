using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ANIMANIA.Models;
using ANIMANIA.Services;
using ANIMANIA.AccesoBD;

namespace ANIMANIA.Dao
{
    public class DetalleOrdenDAO : DetalleOrdenService<DetalleOrden>
    {
        SqlConnection cn = new Acceso().getConnection();
        public int insertarDetalleOrden(DetalleOrden obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_DETALLE_ORDEN_COMPRA",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN",obj.codOrden);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", obj.codProd);
            cmd.Parameters.AddWithValue("@CANTIDAD", obj.cantidad);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", obj.preUnit);
            cmd.Parameters.AddWithValue("@IMPORTE", obj.importe);
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
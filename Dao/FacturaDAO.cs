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
    public class FacturaDAO : FacturaService<Factura>
    {
        SqlConnection cn = new Acceso().getConnection();
        public int insertarFactura(Factura obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_FACTURA",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IGV",obj.IGV);
            cmd.Parameters.AddWithValue("@SUB_TOTAL", obj.subTotal);
            cmd.Parameters.AddWithValue("@DESCUENTO", obj.dscto);
            cmd.Parameters.AddWithValue("@TOTAL", obj.total);
            cmd.Parameters.AddWithValue("@MONEDA", obj.moneda);
            cmd.Parameters.AddWithValue("@ID_ORDEN", obj.idOrden);
            cmd.Parameters.AddWithValue("@ID_TIPO_PAGO", obj.idTipoPago);
            cmd.Parameters.AddWithValue("@ID_TARJETA", obj.idTarjeta);
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
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
    public class TiendaProductoDAO : TiendaProductoService<TiendaProducto>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizasTiendaProducto(TiendaProducto obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_DESPACHAR_SUCURSAL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CANTIDAD", obj.STOCK);
            cmd.Parameters.AddWithValue("@ID_TIENDA_SUCURSAL", obj.ID_TIENDA);
            cmd.Parameters.AddWithValue("@ID_PROD", obj.ID_PRODUCTO);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public List<TiendaProducto> listaTiendaProducto()
        {
            List<TiendaProducto> lista = new List<TiendaProducto>();
            TiendaProducto obj = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIENDA_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new TiendaProducto()
                {
                    ID_TIENDA_PRODUCTO = Int32.Parse(dr[0].ToString()),
                    ID_PRODUCTO = Int32.Parse(dr[1].ToString()),
                    ID_TIENDA = Int32.Parse(dr[2].ToString()),
                    STOCK_PENDIENTE = Int32.Parse(dr[3].ToString())
                };
                lista.Add(obj);
            }
            return lista;
        }
    }
}
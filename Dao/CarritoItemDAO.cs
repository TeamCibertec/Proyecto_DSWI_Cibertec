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
    public class CarritoItemDAO : CarritoItemService<CarritoItem>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizarCarritoItem(CarritoItem obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_TEMP",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_USU",obj.idUsuario);
            cmd.Parameters.AddWithValue("@ID_PROD", obj.idProducto);
            cmd.Parameters.AddWithValue("@CANT", obj.cantProd);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int eliminarCarritoItem(int prod, int usu)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_DELETE_TEMPORAL_CARRITO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_USUARIO",usu);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", prod);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int insertarCarritoItem(CarritoItem obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_TEMPORAL_CARRITO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROD",obj.idProducto);
            cmd.Parameters.AddWithValue("@ID_USU", obj.idUsuario);
            cmd.Parameters.AddWithValue("@PRECIO_PROD", obj.preProd);
            cmd.Parameters.AddWithValue("@CANT_PROD", obj.cantProd);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public List<CarritoItem> listaCarritoItem()
        {
            List<CarritoItem> lista = new List<CarritoItem>();
            CarritoItem item = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TEMPORAL_CARRITO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                item = new CarritoItem()
                {
                    idProducto = Int32.Parse(dr[0].ToString()),
                    idUsuario = Int32.Parse(dr[1].ToString()),
                    preProd = Decimal.Parse(dr[2].ToString()),
                    cantProd = Int32.Parse(dr[3].ToString())
                };
                lista.Add(item);
            }
            cn.Close();
            dr.Close();
            return lista;
        }
    }
}
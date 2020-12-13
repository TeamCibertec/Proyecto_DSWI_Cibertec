using ANIMANIA.AccesoBD;
using ANIMANIA.Models;
using ANIMANIA.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace ANIMANIA.Dao
{
    public class AdminOrdenCompraDAO :  OrdenCompraAdmin<Orden_Compra>
    {
        public int insertarOrdenCompra(Orden_Compra obj)
        {
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ORDEN_COMPRA",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLI_EMP",obj.codCli);
            cmd.Parameters.AddWithValue("@FLAG", obj.flag);
            cmd.Parameters.AddWithValue("@ID_ORDEN", 1).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int num_bol = Int32.Parse(cmd.Parameters["@ID_ORDEN"].Value.ToString());
            return num_bol;
        }

        public List<Orden_Compra> listadoOrdenes() {
            List<Orden_Compra> lista = new List<Orden_Compra>();
            Orden_Compra oc = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ORDEN_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                oc = new Orden_Compra()
                {
                    codOrden = Int32.Parse(dr[0].ToString()),
                    estOrden = Int32.Parse(dr[1].ToString()),
                    estAOrdenDesc = dr[2].ToString(),
                    clienteProv = dr[3].ToString(),
                    codCli = dr[4].ToString(),
                    fecOrden = DateTime.Parse(dr[5].ToString()),
                    flag = dr[6].ToString()
                };
                lista.Add(oc);
            };
            new Acceso().closeConnection(cn);
            return lista;
        }

        public int updateEstadoOrden(int codigo, int estado) {
            int i= 0;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_ESTADO_ORDEN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODORDEN",codigo);
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            i = cmd.ExecuteNonQuery();
            new Acceso().closeConnection(cn);
            return i;
        }

        public List<Orden_Compra> listadoPedidoxcliente(int codigo)
        {
            List<Orden_Compra> lista = new List<Orden_Compra>();
            Orden_Compra ord = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("pedidoxcliente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLIENTE", codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ord = new Orden_Compra()
                {
                    codOrden = Int32.Parse(dr[0].ToString()),
                    estOrden = Int32.Parse(dr[1].ToString()),
                    fecOrden = DateTime.Parse(dr[2].ToString())
                };
                lista.Add(ord);
            }
            return lista;
        }

        public Orden_Compra obtenerOrdenCompra(int codigo)
        {
            Orden_Compra ordencompra = new Orden_Compra();
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ORDEN_COMPRA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_COMPRA", codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ordencompra = new Orden_Compra()
                {
                    codOrden = Int32.Parse(dr["ID_ORDEN_COMPRA"].ToString()),
                    estOrden = Int32.Parse(dr["ESTADO"].ToString()),

                };
            }
            new Acceso().closeConnection(cn);



            return ordencompra;

        }

    }
}
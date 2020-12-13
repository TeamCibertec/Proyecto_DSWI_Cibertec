using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ANIMANIA.AccesoBD;
using ANIMANIA.Models;
using ANIMANIA.Services;
using System.Data.SqlClient;

namespace ANIMANIA.Dao
{
    public class AdminOrdenRecepcionDAO:OrdenRecpService<OrdenRecepcion>
    {
        public int registrarOrdenRecepcion(OrdenRecepcion obj)
        {

            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ORDEN_RECEPCION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_COMPRA", obj.IdOrdencompra);
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", obj.IdEmple);
            cmd.ExecuteNonQuery();
            return 1;
        }

        public List<Orden_Compra> listadoOrdenesRecepcion()
        {
            List<Orden_Compra> lista = new List<Orden_Compra>();
            Orden_Compra oc = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_lISTA_ORDEN_COMPRA_RECEPCION", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                oc = new Orden_Compra()
                {
                    codOrden = Int32.Parse(dr[0].ToString()),
                };
                lista.Add(oc);
            };
            new Acceso().closeConnection(cn);
            return lista;
        }


        public int ActualizarRecepcion(int codigo)
        {

            Console.WriteLine(codigo);
            int ok = 1;

            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_RECEPCION_ORDEN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_COMPRA", codigo);
            cmd.ExecuteNonQuery();

            return ok;
        }


        public int ActualizarTiendaStock(int codigo)
        {
            int ok = 1;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("sp_tab_orden_recpecion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_orden_recp", codigo);
            cmd.ExecuteNonQuery();
            return ok;
        }

        public OrdenRecepcion buscarordenrecepcon(int codigo)
        {
            OrdenRecepcion orden = new OrdenRecepcion();
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("sp_busca_orden_recepcion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_orden_compra", codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                orden = new OrdenRecepcion
                {
                    IdordenRecp = Int32.Parse(dr["ID_ORDEN_RECEP"].ToString()),


                };
            }
            new Acceso().closeConnection(cn);


            return orden;

        }
    }
}
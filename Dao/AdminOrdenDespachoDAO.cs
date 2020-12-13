using ANIMANIA.AccesoBD;
using ANIMANIA.Models;
using ANIMANIA.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ANIMANIA.Dao
{
    public class AdminOrdenDespachoDAO : OrdenDespachoAdminService<OrdenDespacho>
    {
        public int eliminarOrdenDespacho(int codigo)
        {
            int i = 0;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_DELETE_ORDEN_DESPACHO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_DESPACHO",codigo);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int insertarOrdenDespacho(OrdenDespacho obj)
        {
            int i = 0;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ORDEN_DESPACHO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_COMPRA",obj.codOrdenComp);
            cmd.Parameters.AddWithValue("@ID_TIPO_MOV", obj.codTipo);
            cmd.Parameters.AddWithValue("@ID_EMPLEADO", obj.codEmple);
            cmd.Parameters.AddWithValue("@FECHA_ENTREGA",obj.fecEntrega);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public List<OrdenDespacho> listaOrdenDespacho() {
            List<OrdenDespacho> lista = new List<OrdenDespacho>();
            OrdenDespacho od = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ORDEN_DESPACHO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                od = new OrdenDespacho()
                {
                    codOrdDesp = Int32.Parse(dr[0].ToString()),
                    codTipo = Int32.Parse(dr[1].ToString()),
                    desTipo = dr[2].ToString(),
                    fecEntrega = DateTime.Parse(dr[3].ToString()),
                    estOrdDesp = Int32.Parse(dr[4].ToString()),
                    codEmple = Int32.Parse(dr[5].ToString()),
                    nomEmple = dr[6].ToString(),
                    codOrdenComp = Int32.Parse(dr[7].ToString())
                };
                lista.Add(od);
            }
            return lista;
        }

        public OrdenDespacho obtenerDespacho(int codigo) {
            OrdenDespacho orden = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_ORDEN_DESPACHO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ORDEN_DESPACHO", codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                orden = new OrdenDespacho()
                {
                    codOrdDesp = Int32.Parse(dr[0].ToString()),
                    codTipo = Int32.Parse(dr[1].ToString()),
                    fecEntrega = DateTime.Parse(dr[2].ToString()),
                    codEmple = Int32.Parse(dr[4].ToString()),
                    codOrdenComp = Int32.Parse(dr[5].ToString())
                };
            }
            return orden;
        }

    }
}
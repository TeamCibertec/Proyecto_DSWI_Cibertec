using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ANIMANIA.Models;
using ANIMANIA.Services;
using ANIMANIA.AccesoBD;

namespace ANIMANIA.Dao
{
    public class AdminAsignacionDAO : AsignacionAdminService<Asignacion>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int eliminarRol(int cod_asig, int cod_usu)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_ROL", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_ASIG",cod_asig);
            cmd.Parameters.AddWithValue("@ID_USU",cod_usu);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public List<Asignacion> listarAsigaciones()
        {
            List<Asignacion> lista = new List<Asignacion>();
            Asignacion asignacion = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ASIGNACION",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                asignacion = new Asignacion()
                {
                    idAsignacion = Int32.Parse(dr[0].ToString()),
                    nomAsignacion = dr[1].ToString()
                };
                lista.Add(asignacion);
            }
            return lista;
        }

        public List<Asignacion> listarAsignacionesActuales_x_Codigo(int codigo)
        {
            List<Asignacion> lista = new List<Asignacion>();
            Asignacion asi = new Asignacion();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ASIG_X_COD_ACT", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD", codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                asi = new Asignacion()
                {
                    idAsignacion = Int32.Parse(dr[0].ToString()),
                    nomAsignacion = dr[1].ToString(),
                    estado = Int32.Parse(dr[2].ToString())
                };
                lista.Add(asi);
            }
            return lista;
        }

        public List<Asignacion> listarAsignaciones_x_Codigo(int codigo)
        {
            List<Asignacion> lista = new List<Asignacion>();
            Asignacion asi = new Asignacion();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ASIG_X_COD_FAL",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD",codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                asi = new Asignacion()
                {
                    idAsignacion = Int32.Parse(dr[0].ToString()),
                    nomAsignacion = dr[1].ToString(),
                    nomEmpleado = dr[2].ToString()
                };
                lista.Add(asi);
            }
            return lista;
        }

       

    }
}
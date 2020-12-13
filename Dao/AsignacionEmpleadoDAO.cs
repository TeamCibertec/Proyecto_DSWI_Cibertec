using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ANIMANIA.Models;
using ANIMANIA.AccesoBD;
using ANIMANIA.Services;

namespace ANIMANIA.Dao
{
    public class AsignacionEmpleadoDAO : AsignacionEmpleadoAdminService<Asignacion_Empleado>
    {
        SqlConnection cn = new Acceso().getConnection();
        public List<Asignacion_Empleado> buscaAsignacionEmpleado(int cod, String nombre)
        {
            List<Asignacion_Empleado> lista = new List<Asignacion_Empleado>();
            Asignacion_Empleado ae = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_ASIG_EMP", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD",cod);
            cmd.Parameters.AddWithValue("@NOM",nombre);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                ae = new Asignacion_Empleado()
                {
                    idAsigEmp = Int32.Parse(dr[0].ToString()),
                    nomAsignacion = dr[1].ToString(),
                    estAsigEmp = Int32.Parse(dr[2].ToString()),
                    desEstAsigEmp = dr[3].ToString(),
                    nomEmpleado = dr[4].ToString(),
                    idUsuario = Int32.Parse(dr[5].ToString()),
                    idAsignacion = Int32.Parse(dr[6].ToString())
                };
                lista.Add(ae);
            }
            return lista;
        }

        public int insertarAsignacionEmpleado(Asignacion_Empleado obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_ASIG_EMP",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_ASIG",obj.idAsignacion);
            cmd.Parameters.AddWithValue("@COD_USU", obj.idUsuario);
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
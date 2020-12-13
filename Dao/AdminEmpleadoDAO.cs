using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ANIMANIA.Services;
using ANIMANIA.Models;
using ANIMANIA.AccesoBD;

namespace ANIMANIA.Dao
{
    public class AdminEmpleadoDAO : EmpleadoService<Empleado>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizarContrato(Empleado emp)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CONTRATO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_EMP", emp.idEmp);
            cmd.Parameters.AddWithValue("@FEC_INI", emp.fecIni);
            cmd.Parameters.AddWithValue("@FEC_FIN", emp.fecFin);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public List<Empleado> listarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            Empleado emp = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EMPLEADO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                emp = new Empleado()
                {
                    idEmp = Int32.Parse(dr[0].ToString()),
                    docIdent = dr[1].ToString(),
                    nomEmp = dr[2].ToString(),
                    corEmp = dr[3].ToString(),
                    tipoDoc = dr[4].ToString(),
                    direcEmp = dr[5].ToString(),
                    fecNac = DateTime.Parse(dr[6].ToString()),
                    estEmp = Int32.Parse(dr[7].ToString()),
                    fecIni = DateTime.Parse(dr[8].ToString()),
                    fecFin = DateTime.Parse(dr[9].ToString()),
                    desEstEmp = dr[10].ToString()
                };
                lista.Add(emp);
            }
            cn.Close();
            return lista;
        }

        public List<Empleado> listarEmpleadoUsuario()
        {
            List<Empleado> lista = new List<Empleado>();
            Empleado emp = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_EMP_USU",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                emp = new Empleado()
                {
                    idEmp = Int32.Parse(dr[0].ToString()),
                    nomEmp = dr[1].ToString()
                };
                lista.Add(emp);
            }
            cn.Close();
            return lista;
        }

        public int registrarEmpleado(Empleado emp)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_EMPLEADO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DNI_EMPLEADO",emp.docIdent);
            cmd.Parameters.AddWithValue("@NOMBRE_EMPLEADO", emp.nomEmp);
            cmd.Parameters.AddWithValue("@EMAIL_EMPLEADO", emp.corEmp);
            cmd.Parameters.AddWithValue("@TIPO_DOC", emp.tipoDoc);
            cmd.Parameters.AddWithValue("@DIRECCION", emp.direcEmp);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", emp.fecNac);
            i = cmd.ExecuteNonQuery();
            return i;
        }
    }
}
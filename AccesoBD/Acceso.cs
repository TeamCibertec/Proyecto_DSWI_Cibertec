using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ANIMANIA.AccesoBD
{
    public class Acceso
    {

        public SqlConnection getConnection() {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            cn.Open();
            return cn;
        }

        public void closeConnection(SqlConnection cn) {
            if (cn!=null) {
                cn.Close();
            }
        }

        public void closeResultSet(SqlDataReader dr) {
            if (dr!=null) {
                dr.Close();
            }
        }
    }
}
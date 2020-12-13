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
    public class TiendaDAO : TiendaService<Tienda>
    {
        SqlConnection cn = new Acceso().getConnection();

        public List<Tienda> listadoTiendaPorFlagPrincipal(Tienda tie)
        {
            List<Tienda> lista = new List<Tienda>();
            Tienda obj = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM TIENDA WHERE PRINCIPAL_FLAG = @PRINCIPAL_FLAG", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@PRINCIPAL_FLAG", tie.PRINCIPAL_FLAG);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                obj = new Tienda()
                {
                    ID_TIENDA = Int32.Parse(dr["ID_TIENDA"].ToString()),
                    NOMBRE_TIENDA = dr["NOMBRE_TIENDA"].ToString(),
                    DIRECCION = dr["DIRECCION"].ToString(),
                    PRINCIPAL_FLAG = dr["PRINCIPAL_FLAG"].ToString(),
                };
                lista.Add(obj);
            }
            return lista;
        }
    }
}
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
    public class DistritoDAO : DistritoService<Distrito>
    {
        SqlConnection cn = new Acceso().getConnection();

        public List<Distrito> listarDistritos()
        {
            List<Distrito> lista = new List<Distrito>();
            Distrito dis = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DISTRITO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                dis = new Distrito()
                {
                    idDistrito = Int32.Parse(dr[0].ToString()),
                    nomDistrito = dr[1].ToString()
                };
                lista.Add(dis);
            }
            cn.Close();
            return lista;
        }
    }
}
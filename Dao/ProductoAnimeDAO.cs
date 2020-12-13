using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ANIMANIA.AccesoBD;
using ANIMANIA.Models;
using ANIMANIA.Services;

namespace ANIMANIA.Dao
{
    public class ProductoAnimeDAO : ProductoAnimeService<Producto_Anime>
    {
        SqlConnection cn = new Acceso().getConnection();
        public List<Producto_Anime> listarProductoAnime()
        {
            List<Producto_Anime> lista = new List<Producto_Anime>();
            Producto_Anime prod = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PROD_ANIME",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                prod = new Producto_Anime()
                {
                    idAnime = Int32.Parse(dr[0].ToString()),
                    nomAnime = dr[1].ToString()
                };
                lista.Add(prod);
            }
            return lista;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANIMANIA.Services;
using ANIMANIA.AccesoBD;
using System.Data;
using System.Data.SqlClient;
using ANIMANIA.Models;

namespace ANIMANIA.Dao
{
    public class AdminProductoDAO : Admin<Producto>
    {
        public List<Producto> ListadoProductoAdmin() {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto p = new Producto()
                {
                    codProd = Int32.Parse(dr[0].ToString()),
                    codCate = Int32.Parse(dr[1].ToString()),
                    codProv = Int32.Parse(dr[2].ToString()),
                    desProducto = dr[3].ToString(),
                    preProducto = Decimal.Parse(dr[4].ToString()),
                    dsctoProd = Int32.Parse(dr[5].ToString()),
                    desProv = dr[6].ToString(),
                    desCate = dr[7].ToString(),
                    estProd = Int32.Parse(dr[8].ToString()),
                    imgProd = dr[9].ToString(),
                    fecLlegada = DateTime.Parse(dr[10].ToString()),
                    idAnime = Int32.Parse(dr[11].ToString()),
                    nomAnime = dr[12].ToString()
                };
                lista.Add(p);
            }
            new Acceso().closeConnection(cn);
            return lista;
        }


        public Producto ObtenerProductoAdmin(int cod) {
            SqlConnection cn = new Acceso().getConnection();
            Producto p = new Producto();
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", cod);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                p = new Producto()
                {
                    codProd = Int32.Parse(dr[0].ToString()),
                    codCate = Int32.Parse(dr[1].ToString()),
                    codProv = Int32.Parse(dr[2].ToString()),
                    desProducto = dr[3].ToString(),
                    preProducto = Decimal.Parse(dr[4].ToString()),
                    dsctoProd = Int32.Parse(dr[5].ToString()),
                    desProv = dr[6].ToString(),
                    desCate = dr[7].ToString(),
                    estProd = Int32.Parse(dr[8].ToString()),
                    imgProd = dr[9].ToString(),
                    fecLlegada = DateTime.Parse(dr[10].ToString()),
                    idAnime = Int32.Parse(dr[11].ToString()),
                    nomAnime = dr[12].ToString(),
                    stkProd = Int32.Parse(dr[13].ToString())
                };
            }
            new Acceso().closeConnection(cn);
            return p;
        }

        public int ActualizarProductoAdmin(Producto p) {
            SqlConnection cn = new Acceso().getConnection();
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDPROD", p.codProd);
            cmd.Parameters.AddWithValue("@IDCATE", p.codCate);
            cmd.Parameters.AddWithValue("@IDPROV", p.codProv);
            cmd.Parameters.AddWithValue("@DESCRIPCION", p.desProducto);
            cmd.Parameters.AddWithValue("@PRECIO", p.preProducto);
            cmd.Parameters.AddWithValue("@DESCTO", p.dsctoProd);
            cmd.Parameters.AddWithValue("@IMG_PROD", p.imgProd);
            i = cmd.ExecuteNonQuery();
            new Acceso().closeConnection(cn);
            return i;
        }

        public int EliminarProductoAdmin(int cod) {
            SqlConnection cn = new Acceso().getConnection();
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", cod);
            i = cmd.ExecuteNonQuery();
            new Acceso().closeConnection(cn);
            return i;
        }

        public int AñadirProductoAdmin(Producto p) {
            SqlConnection cn = new Acceso().getConnection();
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCATE", p.codCate);
            cmd.Parameters.AddWithValue("@IDPROV", p.codProv);
            cmd.Parameters.AddWithValue("@DESCRIPCION", p.desProducto);
            cmd.Parameters.AddWithValue("@PRECIO", p.preProducto);
            cmd.Parameters.AddWithValue("@DESCTO", p.dsctoProd);
            cmd.Parameters.AddWithValue("@IMG", p.imgProd);
            i = cmd.ExecuteNonQuery();
            new Acceso().closeConnection(cn);
            return i;
        }

        public int ActualizarEstadoProductoAdmin(int cod, int estado) {
            SqlConnection cn = new Acceso().getConnection();
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZA_ESTADO_PRODUCTO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODPROD", cod);
            cmd.Parameters.AddWithValue("@NUEVO_ESTADO", estado);
            i = cmd.ExecuteNonQuery();
            new Acceso().closeConnection(cn);
            return i;
        }


    }
}
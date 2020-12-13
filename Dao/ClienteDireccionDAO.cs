using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANIMANIA.AccesoBD;
using ANIMANIA.Models;
using ANIMANIA.Services;
using System.Data;
using System.Data.SqlClient;

namespace ANIMANIA.Dao
{
    public class ClienteDireccionDAO : ClienteDireccionService<Cliente_Direccion>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizarClienteDireccion(int codCli)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CLI_DIREC",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLI",codCli);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public int insertarClienteDireccion(Cliente_Direccion obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CLIENTE_DIRECCION",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESCRIPCION", obj.desDirec);
            cmd.Parameters.AddWithValue("@ID_CLI", obj.idCli);
            cmd.Parameters.AddWithValue("@ID_DIS", obj.idDis);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public List<Cliente_Direccion> listarClienteDireccion(int codCli)
        {
            List<Cliente_Direccion> lista = new List<Cliente_Direccion>();
            Cliente_Direccion direc = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CLIENTE_DIRECCION",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLI",codCli);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                direc = new Cliente_Direccion()
                {
                    idDirec = Int32.Parse(dr[0].ToString()),
                    desDirec = dr[1].ToString(),
                    idCli = Int32.Parse(dr[2].ToString()),
                    idDis = Int32.Parse(dr[3].ToString()),
                    estCliDis = Int32.Parse(dr[4].ToString()),
                    flag = dr[5].ToString()
                };
                lista.Add(direc);
            }
            return lista;
        }
    }
}
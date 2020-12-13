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
    public class AdminUsuarioDAO : UsuarioAdmin<Usuario>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizarUsuario(Usuario obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_UPDATE_USUARIO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLI",obj.idCliEmp);
            cmd.Parameters.AddWithValue("@COR_CLI", obj.corUsu);
            cmd.Parameters.AddWithValue("@PASW_CLI", obj.passUsu);
            i = cmd.ExecuteNonQuery();
            return i;
        }

        public Usuario buscarUsuario(string cor, string pass)
        {
            Usuario u = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@E_MAIL_USUARIO", cor);
            cmd.Parameters.AddWithValue("@PSSW_USUARIO", pass);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                u = new Usuario()
                {
                    idUsu = Int32.Parse(dr[0].ToString()),
                    corUsu = dr[1].ToString(),
                    nomCliEmp = dr[2].ToString(),
                    idCliEmp = Int32.Parse(dr[3].ToString())
                };
            }
            return u;
        }

        public int insertarUsuario(Usuario obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_USUARIO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COD_CLI_EMP",obj.idCliEmp);
            cmd.Parameters.AddWithValue("@E_MAIL_USUARIO",obj.corUsu);
            cmd.Parameters.AddWithValue("@PSSW_USUARIO", obj.passUsu);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            Usuario usuario = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_USUARIO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                usuario = new Usuario()
                {
                    idUsu = Int32.Parse(dr[0].ToString()),
                    corUsu = dr[1].ToString(),
                    passUsu = dr[2].ToString(),
                    estUsu = Int32.Parse(dr[3].ToString()),
                    desEstUsu = dr[4].ToString(),
                    idCliEmp = Int32.Parse(dr[5].ToString()),
                    nomCliEmp = dr[6].ToString()
                };
                lista.Add(usuario);
            }
            return lista;
        }
    }
}
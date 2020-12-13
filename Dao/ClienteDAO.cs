using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ANIMANIA.Models;
using ANIMANIA.AccesoBD;
using ANIMANIA.Services;
using System.Data;
using System.Data.SqlClient;

namespace ANIMANIA.Dao 
{
    public class ClienteDAO : ClienteService<Cliente>
    {
        SqlConnection cn = new Acceso().getConnection();

        public int actualizarCliente(Cliente obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLIENTE", obj.idCli);  
            cmd.Parameters.AddWithValue("@NOM_CLI", obj.nomCli);
            cmd.Parameters.AddWithValue("@TLF_CLI", obj.telfCli);
            cmd.Parameters.AddWithValue("@DOC_CLI", obj.docCli);
            cmd.Parameters.AddWithValue("@FEC_CLI", obj.fecNacCli);
            cmd.Parameters.AddWithValue("@COR_CLI", obj.corCli);
            i = cmd.ExecuteNonQuery();
            cn.Close();
            return i;
        }

        public Cliente buscarCliente(int cod)
        {
            Cliente c = null;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_CLIENTE",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLIENTE",cod);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                c = new Cliente()
                {
                    idCli = Int32.Parse(dr[0].ToString()),
                    docCli = dr[1].ToString(),
                    nomCli = dr[2].ToString(),
                    fecNacCli = DateTime.Parse(dr[3].ToString()),
                    corCli = dr[4].ToString(),
                    telfCli = dr[5].ToString(),
                    estCli = Int32.Parse(dr[6].ToString()),
                    tipoDoc = dr[7].ToString(),
                    pswCli = dr[8].ToString()
                };
            }
            return c;
        }

        public int registrarCliente(Cliente obj)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_CLIENTE", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DOC", obj.docCli);
            cmd.Parameters.AddWithValue("@NOMBRE_CLIENTE", obj.nomCli);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.fecNacCli);
            cmd.Parameters.AddWithValue("@CELULAR", obj.telfCli);
            cmd.Parameters.AddWithValue("@EMAIL_CLIENTE", obj.corCli);
            cmd.Parameters.AddWithValue("@TIPO_DOC", obj.tipoDoc);
            cmd.Parameters.AddWithValue("@cod", 1).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int cod = Int32.Parse(cmd.Parameters["@cod"].Value.ToString());
            cn.Close();
            return cod;
        }
    }
}
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
    public class TarjetaDAO : TarjetaService<Tarjeta>
    {
        SqlConnection cn = new Acceso().getConnection();
        public int buscarTarjeta(Tarjeta obj)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_TARJETA",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NUM_TRX",obj.numTrx);
            cmd.Parameters.AddWithValue("@FEC", obj.fecVenc);
            cmd.Parameters.AddWithValue("@CVV", obj.CVV);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) {
                i = Int32.Parse(dr[0].ToString());
            }
            return i;
        }
    }
}
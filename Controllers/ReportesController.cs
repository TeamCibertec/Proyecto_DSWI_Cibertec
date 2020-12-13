using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using ANIMANIA.AccesoBD;
using System.Data;
using System.Data.SqlClient;

namespace ANIMANIA.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {
            ViewBag.num = listarOrdenes(-1, -1).ToList().Count;
            ViewBag.cli = new SelectList(listarCliente().ToList(), "idCli", "nomCli");
            return View(listarOrdenes(-1,-1).ToList());
        }

        public List<Reporte_Compras> listarOrdenes(int? mes, int? id) {
            if (mes == -1 || mes == null) { mes = -1; }
            if (id == -1 || id == null) { id = -1; }
            List<Reporte_Compras> lista = new List<Reporte_Compras>();
            Reporte_Compras reporte = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_REPORTE_COMPRAS", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MES", mes);
            cmd.Parameters.AddWithValue("@ID_CLI", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                reporte = new Reporte_Compras()
                {
                    idCompras = Int32.Parse(dr[0].ToString()),
                    fecOrden = DateTime.Parse(dr[1].ToString()),
                    nomCli = dr[2].ToString(),
                    Estado = dr[3].ToString()
                };
                lista.Add(reporte);
            }
            return lista;
        }


        public List<Cliente> listarCliente() {
            List<Cliente> lista = new List<Cliente>();
            Cliente c = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LIST_CLI",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                c = new Cliente()
                {
                    idCli = Int32.Parse(dr[0].ToString()),
                    nomCli = dr[1].ToString()
                };
                lista.Add(c);
            }
            return lista;
        }

        public ActionResult listado(int mes,int cod) {
            ViewBag.num = listarOrdenes(mes, cod).ToList().Count();
            return Json(listarOrdenes(mes,cod).ToList(),JsonRequestBehavior.AllowGet);
        }

    }
}
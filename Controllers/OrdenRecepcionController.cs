using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.AccesoBD;
using System.Data.SqlClient;
using ANIMANIA.Dao;
using ANIMANIA.Models;

namespace ANIMANIA.Controllers
{
    public class OrdenRecepcionController : Controller
    {
        Acceso acceso = new Acceso();
        // GET: OrdenRecepcion
        public ActionResult Index()
        {
            Usuario usuario = (Usuario)Session["login"];
            ViewBag.usuario = usuario.nomCliEmp;
            SqlConnection cn = acceso.getConnection();
            AdminOrdenRecepcionDAO dao = new AdminOrdenRecepcionDAO();
            ViewBag.listaordencompra = new SelectList(dao.listadoOrdenesRecepcion(), "codOrden", "codOrden");
            DateTime time = DateTime.Now;
            ViewBag.fecha = time.ToString("yyyy-MM-dd");
            return View();
        }

        public ActionResult RecepcionarOrden(int parametro)
        {

            int ok = 0;
            int items = 0;
            OrdenRecepcion orden = new OrdenRecepcion();

            SqlConnection cn = acceso.getConnection();
            AdminOrdenRecepcionDAO dao = new AdminOrdenRecepcionDAO();
            ok = dao.ActualizarRecepcion(parametro);

            orden = dao.buscarordenrecepcon(parametro);


            ok = dao.ActualizarTiendaStock(orden.IdordenRecp);
            Console.WriteLine(ok);

            return Json(items, JsonRequestBehavior.AllowGet);
        }

    }
}
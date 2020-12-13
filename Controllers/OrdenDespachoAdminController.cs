using ANIMANIA.AccesoBD;
using ANIMANIA.Dao;
using ANIMANIA.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Constantes;

namespace ANIMANIA.Controllers
{
    public class OrdenDespachoAdminController : Controller
    {
        // GET: OrdenDespachoAdmin
        public ActionResult Index()
        {
            List<Asignacion> asignaciones = (List<Asignacion>) Session["asignaciones"];

            if ((asignaciones.ToList().Where(p => p.idAsignacion == Const.DESPACHO).Any() == false) &&
                (asignaciones.ToList().Where(p => p.idAsignacion == Const.SUPERUSUARIO).Any() == false)) {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }

            DateTime time = DateTime.Now;
            ViewBag.fecha = time.ToString("yyyy-MM-dd");
            ViewBag.listaord = new SelectList(new AdminOrdenCompraDAO().listadoOrdenes().ToList().Where(p => p.estOrden==1 && p.flag.Equals("N")), "codOrden", "codOrden");
            ViewBag.listatipo = new SelectList(listaTipo(),"codTipo", "desTipo");
            ViewBag.listaempleado = new SelectList(new AdminEmpleadoDAO().listarEmpleados().ToList(), "idEmp", "nomEmp");
            return View(new AdminOrdenDespachoDAO().listaOrdenDespacho());
        }


        public List<Tipo_Movilidad> listaTipo() {
            List<Tipo_Movilidad> lista = new List<Tipo_Movilidad>();
            Tipo_Movilidad tipo = null;
            SqlConnection cn = new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_TIPO_MOVILIDAD",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                tipo = new Tipo_Movilidad()
                {
                    codTipo = Int32.Parse(dr[0].ToString()),
                    desTipo = dr[1].ToString(),
                    estTipo = Int32.Parse(dr[2].ToString())
                };
                lista.Add(tipo);
            }
            new Acceso().closeConnection(cn);
            return lista;
        }

        public ActionResult obtenerDespacho(int codigo) {
            return Json(new AdminOrdenDespachoDAO().obtenerDespacho(codigo),JsonRequestBehavior.AllowGet);
        }

        public ActionResult insertarOrdenDespacho(OrdenDespacho obj) {
            return Json(new AdminOrdenDespachoDAO().insertarOrdenDespacho(obj), JsonRequestBehavior.AllowGet);
        }

        public ActionResult eliminarOrdenDespacho(int codigo) {
            return Json(new AdminOrdenDespachoDAO().eliminarOrdenDespacho(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DespachoSucursal()
        {
            Tienda objTienda = new Tienda();
            objTienda.PRINCIPAL_FLAG = "N";
            ViewBag.productos = new SelectList(new AdminProductoDAO().ListadoProductoAdmin(), "codProd", "desProducto");
            ViewBag.tienda = new SelectList(new TiendaDAO().listadoTiendaPorFlagPrincipal(objTienda), "ID_TIENDA", "NOMBRE_TIENDA");
            return View();
        }


        public ActionResult ActualizaStockPendiente(TiendaProducto tienda)
        {
            return Json(new TiendaProductoDAO().actualizasTiendaProducto(tienda), JsonRequestBehavior.AllowGet);
        }

        public ActionResult StockPendiente(int codigo) {
            return Json(new TiendaProductoDAO().listaTiendaProducto().Where(p => p.ID_PRODUCTO == codigo).FirstOrDefault(),JsonRequestBehavior.AllowGet);
        }

    }
}
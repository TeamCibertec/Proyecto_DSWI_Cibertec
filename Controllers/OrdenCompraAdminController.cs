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
    public class OrdenCompraAdminController : Controller
    {
        // GET: OrdenCompraAdmin
        public ActionResult Index()
        {
            List<Asignacion> asignaciones = (List<Asignacion>)Session["asignaciones"];

            if ((asignaciones.ToList().Where(p => p.idAsignacion == Const.COMPRAS).Any() == false) &&
                (asignaciones.ToList().Where(p => p.idAsignacion == Const.SUPERUSUARIO).Any() == false))
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }
            return View(new AdminOrdenCompraDAO().listadoOrdenes());
        }

        public ActionResult ListadoxEstado() {
            Estado_Orden orden = null;
            SqlCommand cmd = new SqlCommand("SP_ORDENES_POR_ESTADO", new Acceso().getConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                orden = new Estado_Orden()
                {
                    Estado_Pendiente = Int32.Parse(dr[0].ToString()),
                    Estado_Aprobado = Int32.Parse(dr[1].ToString()),
                    Estado_Enviado = Int32.Parse(dr[2].ToString()),
                    Estado_Cancelado = Int32.Parse(dr[3].ToString())
                };
            }
            return Json(orden,JsonRequestBehavior.AllowGet);
        }


        public ActionResult updateEstadoOrden(int codigo,int estado) {
            return Json(new AdminOrdenCompraDAO().updateEstadoOrden(codigo,estado),JsonRequestBehavior.AllowGet);
        }

        public ActionResult listaDetalle(int codigo) {
            List<DetalleOrden> lista = new List<DetalleOrden>();
            DetalleOrden orden = null;
            SqlConnection cn= new Acceso().getConnection();
            SqlCommand cmd = new SqlCommand("SP_LISTAR_DETALLE_POR_CODIGO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODORDEN",codigo);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                orden = new DetalleOrden()
                {
                    codDetalle = Int32.Parse(dr[0].ToString()),
                    codOrden = Int32.Parse(dr[1].ToString()),
                    codProd = Int32.Parse(dr[2].ToString()),
                    desProd = dr[3].ToString(),
                    cantidad = Int32.Parse(dr[4].ToString()),
                    preUnit = Decimal.Parse(dr[5].ToString()),
                    importe = Decimal.Parse(dr[6].ToString()),
                    estDet = Int32.Parse(dr[7].ToString())
                };
                lista.Add(orden);
            }
            return Json(lista,JsonRequestBehavior.AllowGet);
        }

    }
}
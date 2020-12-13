using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using ANIMANIA.AccesoBD;
using System.Data.SqlClient;
using ANIMANIA.Dao;

namespace ANIMANIA.Controllers
{
    public class Orden_Compra_ProveedorController : Controller
    {
        Acceso acceso = new Acceso();
        public ActionResult Index()
        {
            SqlConnection cn = acceso.getConnection();
            AdminProductoDAO dao = new AdminProductoDAO();
            ViewBag.productos = new SelectList(dao.ListadoProductoAdmin(), "codProd", "desProducto");
            return View();
        }

        public ActionResult AñadirItem(CarritoItem item) {
            Usuario u = (Usuario) Session["login"];
            item.idUsuario = u.idUsu;
            List<CarritoItem> carrito = null;
            if (Session["carrito_prov"] == null)
            {
                carrito = new List<CarritoItem>();
                carrito.Add(item);
                Session["carrito_prov"] = carrito;
            }
            else {
                int pos = Posicion(item.idProducto);
                if (pos == -1) {
                    carrito = new List<CarritoItem>();
                    carrito = (List<CarritoItem>)Session["carrito_prov"];
                    carrito.Add(item);
                    Session["carrito_prov"] = carrito;
                }
                else {
                    carrito = (List<CarritoItem>)Session["carrito_prov"];
                    int cant = carrito[pos].cantProd += item.cantProd;
                    carrito[pos].cantProd = cant;
                    Session["carrito_prov"] = carrito;
                }
               
            }
            return Json(carrito,JsonRequestBehavior.AllowGet);
        }

        public ActionResult removeItem(int codigo) {
            List<CarritoItem> carrito = (List<CarritoItem>)Session["carrito_prov"];
            int posicion = Posicion(codigo);
            carrito.RemoveAt(posicion);
            Session["carrito_prov"] = carrito;
            return Json(carrito,JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenerarOrden() {
            Usuario usuario = (Usuario)Session["login"];
            OrdenRecepcion ordenRecepcion = new OrdenRecepcion();
            List<CarritoItem> carrito = (List<CarritoItem>)Session["carrito_prov"];
            Orden_Compra oc = new Orden_Compra();
            DetalleOrden detalle = null;
            oc.flag = "Y";
            oc.codCli = usuario.idCliEmp.ToString();
            int codOrden = new AdminOrdenCompraDAO().insertarOrdenCompra(oc);
            int items = 0;
            foreach (CarritoItem item in carrito)
            {
                detalle = new DetalleOrden()
                {
                    codOrden = codOrden,
                    codProd = item.idProducto,
                    cantidad = item.cantProd,
                    preUnit = item.preProd,
                    importe = item.subtotal()
                };
                items += new DetalleOrdenDAO().insertarDetalleOrden(detalle);
            }

            ordenRecepcion.IdOrdencompra = codOrden;
            ordenRecepcion.IdEmple = usuario.idCliEmp;

            AdminOrdenRecepcionDAO daorecep = new AdminOrdenRecepcionDAO();
            daorecep.registrarOrdenRecepcion(ordenRecepcion);

            return Json(items,JsonRequestBehavior.AllowGet);
        }

        public int Posicion(int cod)
        {
            int pos = -1;
            List<CarritoItem> item = (List<CarritoItem>)Session["carrito_prov"];
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].idProducto == cod)
                {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public ActionResult ObtenerOrdenCompra(int parametro)
        {
            return Json(new AdminOrdenCompraDAO().obtenerOrdenCompra(parametro), JsonRequestBehavior.AllowGet);
        }

    }
}
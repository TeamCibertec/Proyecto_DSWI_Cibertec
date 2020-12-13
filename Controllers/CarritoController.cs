using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using ANIMANIA.Dao;
using ANIMANIA.Constantes;

namespace ANIMANIA.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            Usuario usu = (Usuario)Session["login"];
            if (usu == null)
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }else {
                List<CarritoItem> lista = (List<CarritoItem>) Session["carrito"];
                if (lista == null)
                {
                    return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
                }
                else {
                    Session["items"] = lista.ToList().Sum(p => p.cantProd);
                    ViewBag.cant = lista.Count;
                    ViewBag.sub = lista.Sum(p => p.subtotal());
                    ViewBag.delivery = Const.RECARGO_DELIVERY;
                    ViewBag.total = lista.Sum(p => p.subtotal())+Const.RECARGO_DELIVERY;
                    return View(lista);
                }
            }
            
        }

        public ActionResult AgregarAlCarrito(CarritoItem item) {
            List<CarritoItem> lista = null;
            if (Session["carrito"] == null)
            {
                lista = new List<CarritoItem>();
                lista.Add(item);
                Session["carrito"] = lista;
                new CarritoItemDAO().insertarCarritoItem(item);
            }
            else {
                lista = (List<CarritoItem>)Session["carrito"];
                int pos = Posicion(item.idProducto);
                if (pos >= 0)
                {
                    int cant = lista[pos].cantProd += item.cantProd;
                    Session["carrito"] = lista;
                    item.cantProd = cant;
                    new CarritoItemDAO().actualizarCarritoItem(item);
                }
                else {
                   lista.Add(item);
                    Session["carrito"] = lista;
                    new CarritoItemDAO().insertarCarritoItem(item);
                }   
            }
            Session["items"] = lista.ToList().Sum(p => p.cantProd);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public int Posicion(int cod) {
            int pos = -1;
            List<CarritoItem> item = (List<CarritoItem>) Session["carrito"];
            for (int i = 0;i<item.Count;i++) {
                if (item[i].idProducto == cod) {
                    pos = i;
                    break;
                }
            }
            return pos;
        }

        public ActionResult actualizarItemCarrito(CarritoItem item) {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            int pos = Posicion(item.idProducto);
            int cant = lista[pos].cantProd = item.cantProd;
            Session["carrito"] = lista;
            item.cantProd = cant;
            new CarritoItemDAO().actualizarCarritoItem(item);
            return Json(lista,JsonRequestBehavior.AllowGet);
        }

        public ActionResult eliminarCarritoItem(int prod,int usu) {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            int pos = Posicion(prod);
            lista.RemoveAt(pos);
            Session["carrito"] = lista;
            Session["items"] = lista.ToList().Sum(p => p.cantProd);
            new CarritoItemDAO().eliminarCarritoItem(prod,usu);
            return Json(lista.Count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult procesarCompra() {
            Usuario usu = (Usuario)Session["login"];
            Orden_Compra oc = new Orden_Compra();
            DetalleOrden detalle = null;
            oc.codCli = usu.idCliEmp.ToString();
            oc.flag = "N";
            int codOrden = new AdminOrdenCompraDAO().insertarOrdenCompra(oc);
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            foreach (CarritoItem item in lista) {
                detalle = new DetalleOrden()
                {
                    codOrden = codOrden,
                    codProd = item.idProducto,
                    cantidad = item.cantProd,
                    preUnit = item.preProd,
                    importe = item.subtotal()
                };
                new DetalleOrdenDAO().insertarDetalleOrden(detalle);
            }
            Cliente_Direccion cli = new ClienteDireccionDAO().listarClienteDireccion(usu.idCliEmp).ToList().Where(p => p.flag.Equals("Y")).FirstOrDefault();
            ViewBag.direc = cli.desDirec;
            ViewBag.orden = codOrden;
            return View();
        }

        public ActionResult buscarTarjeta(Tarjeta tarjeta) {
            return Json(new TarjetaDAO().buscarTarjeta(tarjeta),JsonRequestBehavior.AllowGet);
        }

        public ActionResult generarFactura(Factura f) {
            List<CarritoItem> lista = (List<CarritoItem>)Session["carrito"];
            decimal sub = lista.Sum(p => p.subtotal());
            f.moneda = Const.MONEDA_PERU;
            f.IGV = Const.IGV;
            f.dscto = Const.DESCUENTO;
            f.subTotal = sub;
            //decimal igv = sub * (Const.IGV/100);
            decimal igv = sub * (decimal) 0.18;
            f.total = sub + Const.RECARGO_DELIVERY + igv;
            Session["carrito"] = null;
            Session["items"] = 0;
            return Json(new FacturaDAO().insertarFactura(f),JsonRequestBehavior.AllowGet);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Dao;

namespace ANIMANIA.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index(int ? cod)
        {
            int paginacion = 0;
            int rows = 6;
            ViewBag.total = Decimal.Round(new AdminProductoDAO().ListadoProductoAdmin().ToList().Count/rows);
            if (cod == null || cod == 1)
            {
                paginacion = 0;
                rows = 6;
            }
            else {
                paginacion = rows * (int) (cod-1);
                rows = rows * (int)cod;
            }

            if (Session["items"] == null) {
                Session["items"] = 0;
            }

            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList().Take(rows).Skip(paginacion));
        }

        public ActionResult listaOferta()
        {
            DateTime time = DateTime.Now;
            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList().Where(p => p.dsctoProd>0 && p.fecLlegada<=time));
        }

        public ActionResult listaNovedad()
        {
            DateTime timeIntervalo = DateTime.Now.AddMonths(-3);
            DateTime timeActual = DateTime.Now;
            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList().Where(p => p.fecLlegada >= timeIntervalo && p.fecLlegada <= timeActual));
        }

        public ActionResult listaReserva()
        {
            DateTime time = DateTime.Now;
            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList().Where(p => p.fecLlegada > time));
        }

        public ActionResult listaProdAnime() {
            return Json(new ProductoAnimeDAO().listarProductoAnime().ToList(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult listaxAnime(int codigo)
        {
            ViewBag.nom = new ProductoAnimeDAO().listarProductoAnime().Where(p => p.idAnime == codigo).FirstOrDefault().nomAnime;
            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList().Where(p => p.idAnime == codigo).OrderBy(p => p.idAnime));
        }

        public ActionResult listaProdAnimeImg(int codigo)
        {
            return Json(new AdminProductoDAO().ListadoProductoAdmin().Where(p => p.idAnime == codigo).FirstOrDefault().imgProd, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetalleProducto(int codigo) 
        {
            return View(new AdminProductoDAO().ObtenerProductoAdmin(codigo));
        }

        public ActionResult Principal()
        {
            return View(new AdminProductoDAO().ListadoProductoAdmin().ToList());
        }

    }
}
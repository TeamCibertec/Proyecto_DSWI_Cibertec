using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ANIMANIA.Dao;
using ANIMANIA.Constantes;
using System.IO;

namespace ANIMANIA.Controllers
{
    public class AdminController : Controller
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        // GET: Producto
        public ActionResult Index()
        {
            List<Asignacion> asignaciones = (List<Asignacion>)Session["asignaciones"];

            if ((asignaciones.ToList().Where(p => p.idAsignacion == Const.PRODUCTOS).Any() == false) &&
                (asignaciones.ToList().Where(p => p.idAsignacion == Const.SUPERUSUARIO).Any() == false))
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }
            List<Producto> lista = new AdminProductoDAO().ListadoProductoAdmin();
            ViewBag.listacate = new SelectList(listadoxCate(), "codCate", "desCate");
            ViewBag.listaprov = new SelectList(listadoxProv(), "codProv", "razSocial");
            ViewBag.count = lista[lista.Count - 1].codProd + 1;
            return View(lista);
        }

        public List<Categoria> listadoxCate() 
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria c = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_CATEGORIA_PRODUCTO",cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                c = new Categoria()
                {
                    codCate = Int32.Parse(dr[0].ToString()),
                    desCate = dr[1].ToString()
                };
                lista.Add(c);
            }
            cn.Close();
            return lista;
        }

        public List<Proveedor> listadoxProv()
        {
            List<Proveedor> lista = new List<Proveedor>();
            Proveedor p = null;
            SqlCommand cmd = new SqlCommand("SP_LISTAR_PROVEEDOR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                p = new Proveedor()
                {
                     codProv = Int32.Parse(dr[0].ToString()),
                     docIdentidad = dr[1].ToString(),
                     razSocial = dr[2].ToString(),
                     dirProv = dr[3].ToString(),
                     corProv = dr[4].ToString(),
                     fecIni = DateTime.Parse(dr[5].ToString()),
                     fecFin = DateTime.Parse(dr[6].ToString()),
                     estProv = Int32.Parse(dr[7].ToString()),
                     desEstProv = dr[8].ToString()
                };
                lista.Add(p);
            }
            cn.Close();
            return lista;
        }

        public ActionResult obtenerProducto(int parametro) 
        {
            return Json(new AdminProductoDAO().ObtenerProductoAdmin(parametro), JsonRequestBehavior.AllowGet);
        }


        public ActionResult insertarProducto(Producto p)
        {
            var img = "/img/"+p.imgProd;
            p.imgProd = img;
            return Json(new AdminProductoDAO().AñadirProductoAdmin(p), JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizarProducto(Producto p)
        {
            if (p.imgProd.Contains("/"))
            {
                p.imgProd = p.imgProd;
            }
            else {
                p.imgProd = "/img/" + p.imgProd;
            }
            return Json(new AdminProductoDAO().ActualizarProductoAdmin(p), JsonRequestBehavior.AllowGet);
        }

        public ActionResult eliminaProducto(int codigo)
        {
            return Json(new AdminProductoDAO().EliminarProductoAdmin(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizarEstado(int codigo,int estado) {
            return Json(new AdminProductoDAO().ActualizarEstadoProductoAdmin(codigo,estado), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductosEnTransito()
        {
            ViewBag.listacate = new SelectList(listadoxCate(), "codCate", "desCate");
            ViewBag.listaprov = new SelectList(listadoxProv(), "codProv", "razSocial");
            return View(new AdminProductoDAO().ListadoProductoAdmin().Where(p => p.estProd == 2));
        }

        public ActionResult imagen() {
            var file = Request.Files[0];
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                file.SaveAs(Server.MapPath("/img/" + fileName));
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

    }
}
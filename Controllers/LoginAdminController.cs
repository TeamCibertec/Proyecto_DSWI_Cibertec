using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Dao;
using ANIMANIA.Models;

namespace ANIMANIA.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult buscarUsuario(String correo, String password) {
            Usuario usu = null;
            usu = new AdminUsuarioDAO().buscarUsuario(correo, password);
            if (usu != null) {
                Session ["login"] = usu;
                List<Asignacion> asig = new AdminAsignacionDAO().listarAsignacionesActuales_x_Codigo(usu.idUsu);
                if (asig.Count() > 0)
                {
                    Session["asignaciones"] = asig;
                }
                else {
                    Session["asignaciones"] = null;
                }
            }    
            return Json(usu, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult CerrarSesion() {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
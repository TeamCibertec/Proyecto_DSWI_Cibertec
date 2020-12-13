using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Dao;
using ANIMANIA.Models;
using ANIMANIA.Constantes;

namespace ANIMANIA.Controllers
{
    public class UsuarioAdminController : Controller
    {
        // GET: UsuarioAdmin
        public ActionResult Index()
        {
            List<Asignacion> asignaciones = (List<Asignacion>)Session["asignaciones"];

            if ((asignaciones.ToList().Where(p => p.idAsignacion == Const.SEGURIDAD).Any() == false) &&
                (asignaciones.ToList().Where(p => p.idAsignacion == Const.SUPERUSUARIO).Any() == false))
            {
                return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
            }
            ViewBag.listaempusu = new SelectList(new AdminEmpleadoDAO().listarEmpleadoUsuario().ToList(), "idEmp", "nomEmp");
            return View(new AdminUsuarioDAO().listarUsuarios().ToList());
        }

        public ActionResult listarporTipoUsuario()
        {
            return Json(new AdminUsuarioDAO().listarUsuarios().ToList(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult obtenerEmpleado(int codigo) {
           Empleado emp = new AdminEmpleadoDAO().listarEmpleados().ToList().Where(p => p.idEmp == codigo).FirstOrDefault();
            return Json(emp,JsonRequestBehavior.AllowGet);
        }

        public ActionResult insertarUsuario(Usuario usu)
        {
            return Json(new AdminUsuarioDAO().insertarUsuario(usu), JsonRequestBehavior.AllowGet);
        }

        public ActionResult buscarAsignacionEmpleado(int codigo,String nom)
        {
            return Json(new AsignacionEmpleadoDAO().buscaAsignacionEmpleado(codigo,nom),JsonRequestBehavior.AllowGet);
        }

        public ActionResult buscarAsignacionesFaltantes(int codigo)
        {
            return Json(new AdminAsignacionDAO().listarAsignaciones_x_Codigo(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult buscarAsignacionesActuales(int codigo)
        {
            return Json(new AdminAsignacionDAO().listarAsignacionesActuales_x_Codigo(codigo), JsonRequestBehavior.AllowGet);
        }

        public ActionResult insertarAsignacionEmpleado(Asignacion_Empleado emp)
        {
            return Json(new AsignacionEmpleadoDAO().insertarAsignacionEmpleado(emp), JsonRequestBehavior.AllowGet);
        }

        public ActionResult eliminarRol(int cod_asig,int cod_usu) {
            int i = 0;
            i = new AdminAsignacionDAO().eliminarRol(cod_asig,cod_usu);
            return Json(i,JsonRequestBehavior.AllowGet);
        }

    }
}
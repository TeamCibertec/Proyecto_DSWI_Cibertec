using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using ANIMANIA.Dao;

namespace ANIMANIA.Controllers
{
    public class EmpleadoAdminController : Controller
    {
        // GET: EmpleadoAdmin
        public ActionResult Index()
        {
            DateTime time = DateTime.Now;
            ViewBag.fechanac = time.AddYears(-16).ToString("yyyy-MM-dd");
            ViewBag.fechaini = time.ToString("yyyy-MM-dd");
            ViewBag.fechafin = time.AddMonths(1).ToString("yyyy-MM-dd");
            return View(new AdminEmpleadoDAO().listarEmpleados());
        }

        public ActionResult Contratos() {

            return View(new AdminEmpleadoDAO().listarEmpleados());
        }

        public ActionResult registroEmpleado(Empleado emple) {

            return Json(new AdminEmpleadoDAO().registrarEmpleado(emple),JsonRequestBehavior.AllowGet);
        }

        public ActionResult obtenerEmpleado(int codigo) {
            return Json(new AdminEmpleadoDAO().listarEmpleados().Find(p=>p.idEmp==codigo),JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizarContrato(Empleado emple) {
            return Json(new AdminEmpleadoDAO().actualizarContrato(emple),JsonRequestBehavior.AllowGet);
        }

    }
}
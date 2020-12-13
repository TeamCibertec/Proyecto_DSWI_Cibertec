using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANIMANIA.Models;
using ANIMANIA.Dao;

namespace ANIMANIA.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ViewBag.distrito = new SelectList(new DistritoDAO().listarDistritos().ToList(), "idDistrito", "nomDistrito");
            return View();
        }

        public ActionResult InformacionPersonal() {
            Usuario u = (Usuario) Session["login"]; 
            return View(new ClienteDAO().buscarCliente(u.idCliEmp));
        }
        public ActionResult registroCliente(Cliente obj) 
        {
            return Json(new ClienteDAO().registrarCliente(obj),JsonRequestBehavior.AllowGet);
        }

        public ActionResult registroUsuCliente(Usuario obj)
        {
            return Json(new AdminUsuarioDAO().insertarUsuario(obj), JsonRequestBehavior.AllowGet);
        }

        public ActionResult registroClienteDireccion(Cliente_Direccion obj)
        {
            if (obj.flag.Equals("Y")) {
                new ClienteDireccionDAO().actualizarClienteDireccion(obj.idCli); 
            }
            return Json(new ClienteDireccionDAO().insertarClienteDireccion(obj), JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizarCliente(Cliente c) {
            int i = 0;
            Usuario u = new Usuario();
            u.corUsu = c.corCli;
            u.idCliEmp = c.idCli;
            u.passUsu = c.pswCli;
            i += new AdminUsuarioDAO().actualizarUsuario(u);
            i += new ClienteDAO().actualizarCliente(c);
            return Json(i,JsonRequestBehavior.AllowGet);
        }

        public ActionResult actualizarDistritoCliente() {
            ViewBag.distrito = new SelectList(new DistritoDAO().listarDistritos().ToList(), "idDistrito", "nomDistrito");
            Usuario usu = (Usuario)Session["login"];
            return View(new ClienteDireccionDAO().listarClienteDireccion(usu.idCliEmp).ToList());
        }

        public ActionResult pedidoCliente()
        {
            Usuario usu = (Usuario)Session["login"];
            return View(new AdminOrdenCompraDAO().listadoPedidoxcliente(usu.idCliEmp).ToList());
        }

    }
}
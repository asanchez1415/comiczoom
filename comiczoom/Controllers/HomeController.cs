using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Autenticación
using System.Web.Security;
// Uso de roles
using prueba.Models;

namespace prueba.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.NombreUsuario = Session["Nombres"];
            return View();
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Em"] = null;
            return RedirectToAction("Login", "Login");
        }

        public ActionResult NoAccess()
        {
            ViewBag.NombreUsuario = Session["Nombres"];
            return View();
        }


    }
}
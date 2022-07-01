using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Trae el modelo correspondientes para el login
using prueba.Models;
// Autenticación
using System.Web.Security;

namespace prueba.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Rut, string Contrasenia)
        {
            UserLogin user = new UserLogin().Verify(Rut, Contrasenia);

            if (user.Nombres != null)
            {
                FormsAuthentication.SetAuthCookie(user.Rut, false);
                Session["Em"] = user;
                Session["IdRol"] = (int)user.IdRol;
                Session["Nombres"] = user.Nombres;
                Session["idEMP"] = user.Id;
                Session["idSUC"] = user.IdSUC;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.BadLog = "*Rut o contraseña incorrectos";
                return RedirectToAction("Login", "Login");

            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

    }
}
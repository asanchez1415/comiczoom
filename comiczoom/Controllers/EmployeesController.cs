using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EmployeeList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];
            return View();
        }
    }
}
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
    public class EmployeesController : Controller
    {
        // GET: Employees
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EmployeeList(FormCollection formCollection)
        {
            Employee listaEmpleados = new Employee();

            string _rut = formCollection["Rut"];
            string _nombre = formCollection["Nombre"];

            if (_rut != "" && _nombre != "")
            {
            }

            ViewBag.NombreUsuario = Session["Nombres"];
            // Mandar empleados
            ViewBag.Empleados = listaEmpleados.ListarEmpleados(_rut, _nombre);
            // Mandar combobox de rut
            ViewBag.ComboRut = listaEmpleados.ComboRut();
            // Mandar combobox de nombres
            ViewBag.ComboNombre = listaEmpleados.ComboNombre();

            return View();
        }
    }
}
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
        Employee emp = new Employee();
        Branches com = new Branches();
        Region reg = new Region();
        Provincia prov = new Provincia();
        Comuna cmn = new Comuna();
        TipoEmpleado te = new TipoEmpleado();

        // GET: Employees
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EmployeeList(FormCollection formCollection)
        {
            string _rut = formCollection["Rut"];
            string _cargo = formCollection["Cargo"];
            string _sucursal = formCollection["Sucursal"];

            ViewBag.NombreUsuario = Session["Nombres"];
            // Mandar empleados
            ViewBag.Empleados = emp.ListarEmpleados(_rut, _sucursal, _cargo);
            // Mandar combobox de rut
            ViewBag.ComboRut = emp.ComboRut();
            // Mandar combobox de sucursales
            ViewBag.ComboSucursal = com.ComboSucursal();
            // Mandar combobox de tipos de empleados
            ViewBag.ComboTE = te.ComboTE();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateEmployee()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combobox
            ViewBag.ComboSucursal = com.ComboSucursal();
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();
            ViewBag.ComboTE = te.ComboTE();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertEmployee(FormCollection formCollection)
        {
            var empleado = new Employee()
            {
                Rut = formCollection["inpRut"],
                IdSUC = Convert.ToInt32(formCollection["inpSucursal"]),
                IdRol = Convert.ToInt32(formCollection["inpCargo"]),
                Nombre = formCollection["inpNombre"],
                SegNombre = formCollection["inpSegNombre"],
                Apellido = formCollection["inpApellido"],
                SegApellido = formCollection["inpSegApellido"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Correo = formCollection["inpCorreo"],
                Contrasenia = formCollection["inpContrasenia"],
            };

            emp.InsertarEmpleado(empleado);

            return RedirectToAction("EmployeeList", "Employees");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EditEmployee()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.Empleado = id;

            // Mandar combobox
            ViewBag.ComboSucursal = com.ComboSucursal();
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();
            ViewBag.ComboTE = te.ComboTE();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public void UpdateEmployee(FormCollection formCollection)
        {
            var empleado = new Employee()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                IdSUC = Convert.ToInt32(formCollection["inpSucursal"]),
                Nombre = formCollection["inpNombre"],
                SegNombre = formCollection["inpSegNombre"],
                Apellido = formCollection["inpApellido"],
                SegApellido = formCollection["inpSegApellido"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Correo = formCollection["inpCorreo"]
            };

            emp.ActualizarEmpleado(empleado);

            Response.Redirect("/Employees/EditEmployee?id=" + empleado.Id);
        }
    }
}
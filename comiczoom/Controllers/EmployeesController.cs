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
        // --Clase/Model de empleados
        Employee emp = new Employee();

        // GET: Employees
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EmployeeList(FormCollection formCollection)
        {
            // --Clase/Model de sucursal
            Branches com = new Branches();
            
            // --Clase/Model de region
            Region reg = new Region();

            // --Clase/Model de provincia
            Provincia prov = new Provincia();

            // --Clase/Model de provincia
            Comuna cmn = new Comuna();

            // --Clase/Model de tipos de empleado
            TipoEmpleado te = new TipoEmpleado();

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
            // Mandar combobox de regiones
            ViewBag.ComboRegion = reg.ComboReg();
            // Mandar combobox de provincias
            ViewBag.ComboProv = prov.ComboProv();
            // Mandar combobox de comunas
            ViewBag.ComboCmn = cmn.ComboCmn();
            // Mandar combobox de tipos de empleados
            ViewBag.ComboTE = te.ComboTE();
            ViewBag.ErrorInsertEmpleado = "d-none";

            return View();
        }

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
    }
}
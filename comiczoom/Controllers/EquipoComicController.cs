using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prueba.Models;
using prueba.Models.EquipoComic;

namespace prueba.Controllers
{
    [Authorize]
    public class EquipoComicController : Controller
    {
        EquipoComic ec = new EquipoComic();
        EmpleadoEquipoComic eec = new EmpleadoEquipoComic();
        TipoEmpleado te = new TipoEmpleado();
        List<Employee> empList = new List<Employee>();
        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EquipoComicList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.Comic = id;
            
            EquipoComic ec2 = ec.ObtenerEquipoComic(ViewBag.Comic)[0];
            List<EmpleadoEquipoComic> EECList = eec.ListarEEC(ec2.Id);          
            foreach (EmpleadoEquipoComic eec in EECList)
            {
                Employee res = new Employee();
                Employee emp = res.ObtenerEmpleado(eec.IdEMP.ToString())[0];

                empList.Add(emp);
            }
            ViewBag.ListaEmpleados = empList;

            return View();
        }

        public ActionResult EliminarEmpleado()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            eec.DeleteEmpleado(id);
            
            //El redirect vuelve a pedir la id del comic.
            return RedirectToAction("EquipoComicList", "EquipoComic");
        }

        public ActionResult AddEmpleadoEC(FormCollection formCollection)
        {
            /*string _cargo = formCollection["cargo"];
            (Antiguo intento de ideas)
            ViewBag.ComboTE = te.ComboTE();
            ViewBag.Empleados = emp.ListarEmpleados(null, null, _cargo);*/
            return View();
        }
    }
}
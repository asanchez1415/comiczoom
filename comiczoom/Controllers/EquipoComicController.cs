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
        Comic res = new Comic();
        EquipoComic ec = new EquipoComic();
        EmpleadoEquipoComic eec = new EmpleadoEquipoComic();
        List<Employee> empList = new List<Employee>();
        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EquipoComicList()
        {

            string id = Request.QueryString["id"].ToString();

            ViewBag.Comic = id;
            ViewBag.NombreUsuario = Session["Nombres"];
            EquipoComic ec2 = ec.ObtenerEquipoComic(ViewBag.Comic)[0];
            ViewBag.EEC = eec.ListarEEC(ec2.Id);          
            foreach (EmpleadoEquipoComic eec in ViewBag.EEC)
            {
                Employee res = new Employee();
                Employee emp = res.ObtenerEmpleado(eec.IdEMP.ToString())[0];

                empList.Add(emp);
            }
            ViewBag.ListaEmpleados = empList;
            
            return View();
        }
    }
}
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

        //
        Employee emp = new Employee();

        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EquipoComicList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ViewBag.Comic = id;

            return View();
        }

        public void EliminarEmpleado()
        {
            int ideec = Convert.ToInt32(Request.QueryString["id"]);
            int idec = Convert.ToInt32(Request.QueryString["idec"]);
            eec.DeleteEmpleado(ideec);
            
            //El redirect vuelve a pedir la id del comic.
            Response.Redirect("/EquipoComic/EquipoComicList?id=" + idec);
        }

        public ActionResult AddEmpleadoEC()
        {
            ViewBag.ComboTE = te.ComboTE();
            ViewBag.Empleados = emp.ListarEmpleados(null, null, null);
            ViewBag.idec = Convert.ToInt32(Request.QueryString["idec"]);

            return View();
        }

        public void InsertEmpleadoEC(FormCollection formCollection)
        {
            int _idEMP = Convert.ToInt32(formCollection["inpEmp"]);
            int _idec = Convert.ToInt32(formCollection["idEC"]);
            string _rol = formCollection["inpCargo"];

            eec.InsertEmpleadoPorEC(_idEMP, _idec,_rol);
            Response.Redirect("/EquipoComic/EquipoComicList?id=" + _idec);
        }
    }
}
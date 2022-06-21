using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using prueba.Models;

namespace prueba.Controllers
{
    [Authorize]
    public class ComicsController : Controller
    {
        Comic com = new Comic();
        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult ComicsList(FormCollection formCollection)
        {
            string _categoria = formCollection["Categoria"];
            string _estado = formCollection["Estado"];
           

            ViewBag.Comics = com.ListarComics(_estado, _categoria);
            ViewBag.ComboCategoria = com.ComboCategoria();
            ViewBag.ComboEstado = com.ComboEstado();
            ViewBag.ErrorInsertComic = "d-none";
            return View();
        }
    }
}
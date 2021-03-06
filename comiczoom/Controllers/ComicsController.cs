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
    public class ComicsController : Controller
    {
        Comic com = new Comic();
        EquipoComic EC = new EquipoComic();
        PrecioSucursal PS = new PrecioSucursal();
        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult ComicsList(FormCollection formCollection)
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string _categoria = formCollection["Categoria"];
            string _estado = formCollection["Estado"];
            
            ViewBag.Comics = com.ListarComics(_estado, _categoria);
            ViewBag.ComboCategoria = com.ComboCategoria();
            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateComic()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combobox
            ViewBag.ComboCategoria = com.ComboCategoria();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertComic(FormCollection formCollection)
        {
            Branches res = new Branches();
            List<Branches> sucList = res.ComboSucursal();

            int numEstado;
            if (formCollection["inpEstado"].Equals("En Desarrollo"))
            {
                numEstado = 0;
            }
            else if (formCollection["inpEstado"].Equals("En Venta"))
            {
                numEstado = 1;
            }
            else
            {
                numEstado = 2;
            }

            var comic = new Comic()
            {
                Nombre = formCollection["inpNombre"],
                Volumen = Convert.ToInt32(formCollection["inpVolumen"]),
                Estado = formCollection["inpEstado"],
                intEstado = numEstado,
                Isbn = formCollection["inpIsbn"],
                Categoria = formCollection["inpCategoria"],
                fechaCreacion = DateTime.Now.Date
            };

            int idInsertado = com.InsertarComic(comic);

            EC.InsertarEquipoComic(idInsertado);

            for(int i = 0; i < sucList.Count; i++)
            {
                PS.InsertarPrecioSucursal(sucList[i].IdSUC, idInsertado);
            }

            return RedirectToAction("ComicsList", "Comics");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EditComic(FormCollection formCollection)
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.Comics = id;

            // Combobox
            ViewBag.ComboCategoria = com.ComboCategoria();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public void UpdateComic(FormCollection formCollection)
        {
            int numEstado;
            if (formCollection["inpEstado"].Equals("En Desarrollo"))
            {
                numEstado = 0;
            }
            else if (formCollection["inpEstado"].Equals("En Venta"))
            {
                numEstado = 1;
            }
            else
            {
                numEstado = 2;
            }

            var comic = new Comic()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                Nombre = formCollection["inpNombre"],
                Volumen = Convert.ToInt32(formCollection["inpVolumen"]),
                Estado = formCollection["inpEstado"],
                intEstado = numEstado,
                Isbn = formCollection["inpIsbn"],
                Categoria = formCollection["inpCategoria"],
                fechaCreacion = DateTime.Now.Date
            };

            com.ActualizarComic(comic);

            Response.Redirect("/Comics/EditComic?id=" + comic.Id);
        }
    }
}
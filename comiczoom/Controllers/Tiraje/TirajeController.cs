using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using prueba.Models.Tiraje;

namespace prueba.Controllers.Tiraje
{
    [Authorize]
    public class TirajeController : Controller
    {
        Tirajes t = new Tirajes();
        DetalleTiraje dt = new DetalleTiraje();

        Branches suc = new Branches();
        Comic comic = new Comic(); 

        // GET: Tiraje
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult TirajeList(FormCollection formCollection)
        {
            string _suc = formCollection["Sucursal"];
            string _fecha = formCollection["Fecha"];
            string _estado = formCollection["Estado"];

            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ComboSuc = suc.ComboSucursal();
            ViewBag.Tir = t.ListarTirajes(_suc, _fecha, _estado);

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateTiraje()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combos
            ViewBag.ComboSuc = suc.ComboSucursal();
            ViewBag.ComboComics = comic.ComboComic();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertTiraje(FormCollection formCollection)
        {
            int contador = Convert.ToInt32(formCollection["contador"]);

            int _suc = Convert.ToInt32(formCollection["inpSuc"]);
            int idInsertado = t.InsertarTiraje(_suc);


            for (int i = 1; i <= contador; i++)
            {
                string com = formCollection[$"com{i}"];
                int cant = Convert.ToInt32(formCollection[$"cant{i}"]);
                decimal cos = Convert.ToDecimal(formCollection[$"costo{i}"]);
                dt.InsertarDetallesPorTiraje(idInsertado, com, cant, cos);

            }

            return RedirectToAction("TirajeList", "Tiraje");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult DeleteTIR()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            t.EliminarTiraje(id);

            return RedirectToAction("TirajeList", "Tiraje");
        }
    }
}
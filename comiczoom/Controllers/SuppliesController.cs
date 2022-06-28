using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    
    public class SuppliesController : Controller
    {
        Insumos ins = new Insumos();
        Rubros rub = new Rubros();
        // GET: Supplies
        public ActionResult SuppliesList(FormCollection formCollection)
        {
            string _rubro = formCollection["rubro"];

            ViewBag.NombreUsuario = Session["Nombres"];

            //Principal
            ViewBag.ListIns = ins.ListarInsumos(_rubro);

            //Combobox
            ViewBag.ComboRub = rub.ComboRubro();

            return View();
        }
        public void UpdateSupply(FormCollection formCollection)
        {
            var insumo = new Insumos()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                IdRUB = Convert.ToInt32(formCollection["inpIdRUB"]),
                Nombre = formCollection["inpNombre"].ToUpper(),
                Descripcion = formCollection["inpDescripcion"],
            };

            ins.ActualizarInsumo(insumo);

            Response.Redirect("/Supplies/EditSupply?id=" + insumo.Id);
        }
        public ActionResult EditSupply()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.ListIns = id;

            // Mandar combobox
            ViewBag.ComboRub = rub.ComboRubro();

            return View();
        }
        public ActionResult CreateSupplies()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ComboRub = rub.ComboRubro();

            return View();
        }
        public ActionResult InsertSupplies(FormCollection formCollection)
        {
            var insumo = new Insumos()
            {
                IdRUB = Convert.ToInt32(formCollection["inpIdRUB"]),
                Nombre = formCollection["inpNombre"].ToUpper(),
                Descripcion = formCollection["inpDescripcion"],
            };

            ins.InsertarInsumos(insumo);

            return RedirectToAction("SuppliesList", "Supplies");
        }
    }
}
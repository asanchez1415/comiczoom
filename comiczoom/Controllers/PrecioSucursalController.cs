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
    public class PrecioSucursalController : Controller
    {
        PrecioSucursal ps = new PrecioSucursal();

        // GET: Comics
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult PrecioSucursalList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ViewBag.Comic = id;

            return View();
        }

        public ActionResult EditPrecioSucursal()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            ViewBag.PrecioSucursal = id;

            return View();
        }

        public void UpdatePrecioSucursal(FormCollection formCollection)
        {
            var PS = new PrecioSucursal()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                IdCOM = Convert.ToInt32(formCollection["inpIdCOM"]),
                Normal = Convert.ToDecimal(formCollection["inpNormal"]),
                AlMayor = Convert.ToDecimal(formCollection["inpAlMayor"]),
                Oferta = Convert.ToDecimal(formCollection["inpOferta"]),
            };

            ps.ActualizarPrecioSucursal(PS);

            Response.Redirect("/PrecioSucursal/PrecioSucursalList?id=" + PS.IdCOM);
        }
    }
}
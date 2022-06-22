using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using prueba.Models.OrdenesCompra;

namespace prueba.Controllers.OC
{
    public class OrdenCompraController : Controller
    {
        OrdenesCompra oc = new OrdenesCompra();
        Proveedor prov = new Proveedor();
        Branches suc = new Branches();
        // GET: OrdenCompra
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult OCList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];
            ViewBag.OCS = oc.ListarProveedores();
            // Combos
            ViewBag.ComboProv = prov.ComboPro();
            ViewBag.ComboSuc = suc.ComboSucursal();

            return View();
        }
    }
}
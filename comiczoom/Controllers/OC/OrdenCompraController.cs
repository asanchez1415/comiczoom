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
        public ActionResult OCList(FormCollection formCollection)
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string _prov = formCollection["Proveedor"];
            string _suc = formCollection["Sucursal"];
            string _fecha = formCollection["Fecha"];
            string _estado = formCollection["Estado"];

            ViewBag.OCS = oc.ListarProveedores(_prov, _suc, _fecha, _estado);
            // Combos
            ViewBag.ComboProv = prov.ComboPro();
            ViewBag.ComboSuc = suc.ComboSucursal();

            return View();
        }

        public ActionResult CreateOC()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combos
            ViewBag.ComboProv = prov.ComboPro();
            ViewBag.ComboSuc = suc.ComboSucursal();

            return View();
        }

        public ActionResult InsertOc(FormCollection formCollection)
        {
            int contador = Convert.ToInt32(formCollection["contador"]);

            string _prov = formCollection["inpProv"];
            string _suc = formCollection["inpSuc"];

            List<string> insumo = new List<string>();
            List<string> cantidad = new List<string>();

            for (int i = 1; i <= contador; i++)
            {
                string ins = formCollection[i];
                string cant = formCollection[$"cant{i}"];
                insumo.Add(ins);
                cantidad.Add(cant);
            }

            return View();
        }
    }
}
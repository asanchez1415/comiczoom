using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using prueba.Models.OrdenesCompra;

namespace prueba.Controllers.OC
{
    [Authorize]
    public class OrdenCompraController : Controller
    {
        OrdenesCompra oc = new OrdenesCompra();
        Proveedor prov = new Proveedor();
        Branches suc = new Branches();
        Insumos ins = new Insumos();
        DetalleOC deoc = new DetalleOC();

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

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateOC()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combos
            ViewBag.ComboProv = prov.ComboPro();
            ViewBag.ComboSuc = suc.ComboSucursal();
            ViewBag.ComboInsumos = ins.ComboIns();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertOc(FormCollection formCollection)
        {
            int contador = Convert.ToInt32(formCollection["contador"]);

            int _suc = Convert.ToInt32(formCollection["inpSuc"]);
            int _prov = Convert.ToInt32(formCollection["inpProv"]);

            List<string> insumo = new List<string>();
            List<int> cantidad = new List<int>();
            List<decimal> precio = new List<decimal>();

            for (int i = 1; i <= contador; i++)
            {
                string ins = formCollection[$"ins{i}"];
                int cant = Convert.ToInt32(formCollection[$"cant{i}"]);
                decimal pre = Convert.ToDecimal(formCollection[$"pre{i}"]);
                insumo.Add(ins);
                cantidad.Add(cant);
                precio.Add(pre);
            }

            //
            int idInsertado = oc.InsertarOC(_suc, _prov);

            for (int i = 0; i < contador; i++)
            {
                deoc.InsertarDetallesPorOC(idInsertado, insumo[i], cantidad[i], precio[i]);
            }

            return RedirectToAction("OCList", "OrdenCompra");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult DeleteOC()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            oc.EliminarOC(id);

            return RedirectToAction("OCList", "OrdenCompra");
        }

    }
}
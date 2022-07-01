using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class StockSuppliesController : Controller
    {
        StockInsumos si = new StockInsumos();
        Insumos ins = new Insumos();
        Branches bra = new Branches();
        // GET: StockSupplies
        public ActionResult StockSuppList(FormCollection formCollection)
        {
            string _insumo = formCollection["Insumos"];

            string _sucursal = formCollection["Sucursal"];

            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ListSI = si.ListarStockInsumos(_insumo, _sucursal);

            ViewBag.ComboIns = ins.ComboIns();

            ViewBag.ComboSuc = bra.ComboSucursal();

            return View();
        }
    }
}
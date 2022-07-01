using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class StockComicsController : Controller
    {
        StockComics sc = new StockComics();
        Comic com = new Comic();
        Branches bra = new Branches();
        // GET: StockComics
        public ActionResult StockComList(FormCollection formCollection)
        {
            string _comic = formCollection["Comics"];

            string _sucursal = formCollection["Sucursal"];

            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ListCom = sc.ListarStockComics(_comic, _sucursal);

            ViewBag.ComboCom = com.ComboComic();

            ViewBag.ComboSuc = bra.ComboSucursal();

            return View();
        }
    }
}
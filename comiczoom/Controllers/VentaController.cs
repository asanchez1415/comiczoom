using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class VentaController : Controller
    {
        Venta ven = new Venta();
        DetalleVenta dv = new DetalleVenta();

        Clients cli = new Clients();
        Employee emp = new Employee();
        Branches br = new Branches();
        Comic comic = new Comic();

        // GET: Venta
        public ActionResult ListaVentas(FormCollection formCollection)
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ListClientes = cli.ListarClientes(null);
            ViewBag.ListEmpleados = emp.ListarEmpleados(null, null, null);
            ViewBag.ListSuc = br.ComboSucursal();

            string _suc = formCollection["Sucursal"];
            string _cli = formCollection["Cliente"];
            string _emp = formCollection["Empleado"];

            ViewBag.ListVentas = ven.ListarVentas(_suc, _cli, _emp, null);

            return View();
        }

        public ActionResult CreateVenta()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.IdEMP = Session["idEMP"];
            ViewBag.IdSUC = Session["idSUC"];
            // Combos
            ViewBag.ListClientes = cli.ListarClientes(null);
            ViewBag.ComboComics = comic.ComboComic();

            return View();
        }

        public ActionResult InsertTiraje(FormCollection formCollection)
        {
            int contador = Convert.ToInt32(formCollection["contador"]);
            int idEMP = Convert.ToInt32(formCollection["idEMP"]);
            int idSUC = Convert.ToInt32(formCollection["idSUC"]);

            int idCli = Convert.ToInt32(formCollection["inpCLI"]);

            int idInsertado = ven.InsertarVenta(idSUC, idCli, idEMP);


            for (int i = 1; i <= contador; i++)
            {
                int com = Convert.ToInt32(formCollection[$"com{i}"]);
                int cant = Convert.ToInt32(formCollection[$"cant{i}"]);
                decimal cos = Convert.ToDecimal(formCollection[$"costo{i}"]);

                dv.InsertarDetallePorVenta(idInsertado, com, cant, cos);

            }

            return RedirectToAction("ListaVentas", "Venta");
        }

        public ActionResult Detalle()
        {
            string id = Request.QueryString["id"];
            ViewBag.idVen = id;

            return View();
        }
    }
}
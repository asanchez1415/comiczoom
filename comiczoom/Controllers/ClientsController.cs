using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    public class ClientsController : Controller
    {
        Clients cli = new Clients();
        Region reg = new Region();
        Provincia prov = new Provincia();
        Comuna cmn = new Comuna();
        // GET: Clients
        public ActionResult ClientsList(FormCollection formCollection)
        {
            string _rut = formCollection["rut"];

            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.Clientes = cli.ListarClientes(_rut);

            ViewBag.ComboRut = cli.ComboRut();

            return View();
        }
        public ActionResult CreateClient()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combobox
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();

            return View();
        }
        public ActionResult InsertClient(FormCollection formCollection)
        {
            var cliente = new Clients()
            {
                Rut = formCollection["inpRut"],
                Nombre = formCollection["inpNombre"],
                SegNombre = formCollection["inpSegNombre"],
                Apellido = formCollection["inpApellido"],
                SegApellido = formCollection["inpSegApellido"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Tipo = formCollection["inpTipo"]
            };

            cli.InsertarCliente(cliente);

            return RedirectToAction("ClientsList", "Clients");
        }
        public ActionResult EditClient()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.Clientes = id;

            // Mandar combobox
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();

            return View();
        }
        public void UpdateClient(FormCollection formCollection)
        {
            var cliente = new Clients()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                Nombre = formCollection["inpNombre"],
                SegNombre = formCollection["inpSegNombre"],
                Apellido = formCollection["inpApellido"],
                SegApellido = formCollection["inpSegApellido"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Tipo = formCollection["inpTipo"]
            };

            cli.ActualizarCliente(cliente);

            Response.Redirect("/Clients/EditClient?id=" + cliente.Id);
        }
    }

}
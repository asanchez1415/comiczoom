using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;

namespace prueba.Controllers
{
    [Authorize]
    public class ProvidersController : Controller
    {
        // --Clase/Model
        Proveedor pro = new Proveedor();
        Rubros rub = new Rubros();
        Region reg = new Region();
        Provincia prov = new Provincia();
        Comuna cmn = new Comuna();

        // GET: Providers
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult ProviderList(FormCollection formCollection)
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string _rubro = formCollection["rubro"];
            string _nombre = formCollection["nombre"];

            // Principal (lista)
            ViewBag.ListPro = pro.ListarProveedores(_rubro, _nombre);
            
            // Combobox
            ViewBag.ComboRub = rub.ComboRubro();
            ViewBag.ComboNombre = pro.ComboNombre();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateProvider()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combobox
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();
            ViewBag.ComboRub = rub.ComboRubro();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertProvider(FormCollection formCollection)
        {
            var proveedor = new Proveedor()
            {
                Rut = formCollection["inpRut"],
                Nombre = formCollection["inpNombre"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Correo = formCollection["inpCorreo"],
                idRUB = Convert.ToInt32(formCollection["inpRub"]),
            };

            pro.InsertarProveedor(proveedor);

            return RedirectToAction("ProviderList", "Providers");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EditProvider()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.Proveedor = id;

            // Combobox
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();
            ViewBag.ComboRub = rub.ComboRubro();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public void UpdateProvider(FormCollection formCollection)
        {
            var proveedor = new Proveedor()
            {
                Id = Convert.ToInt32(formCollection["inpId"]),
                Rut = formCollection["inpRut"],
                Nombre = formCollection["inpNombre"],
                Direccion = formCollection["inpDireccion"],
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
                Telefono = formCollection["inpCelular"],
                Correo = formCollection["inpCorreo"],
                idRUB = Convert.ToInt32(formCollection["inpRub"]),
            };

            pro.ActualizarEmpleado(proveedor);

            Response.Redirect("/Providers/EditProvider?id=" + proveedor.Id);
        }
    }
}
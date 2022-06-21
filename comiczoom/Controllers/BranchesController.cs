using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.Controllers
{
    [Authorize]
    public class BranchesController : Controller
    {
        Branches br = new Branches();
        Region reg = new Region();
        Provincia prov = new Provincia();
        Comuna cmn = new Comuna();

        // GET: Branches
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult BranchesList()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            ViewBag.ListBranch = br.ListarSucursales();
            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult CreateBranch()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            // Combobox
            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult InsertBranch(FormCollection formCollection)
        {
            var branch = new Branches()
            {
                Sucursal = formCollection["inpNombre"].ToString(),
                Direccion = formCollection["inpDireccion"].ToString(),
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
            };

            br.InsertarSucursal(branch);
            return RedirectToAction("BranchesList", "Branches");
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult EditBranch()
        {
            ViewBag.NombreUsuario = Session["Nombres"];

            string id = Request.QueryString["id"].ToString();

            ViewBag.IdSucursal = id;

            ViewBag.ComboRegion = reg.ComboReg();
            ViewBag.ComboProv = prov.ComboProv();
            ViewBag.ComboCmn = cmn.ComboCmn();

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public void UpdateBranch(FormCollection formCollection)
        {
            var branch = new Branches()
            {
                IdSUC = Convert.ToInt32(formCollection["inpId"]),
                Sucursal = formCollection["inpNombre"].ToString(),
                Direccion = formCollection["inpDireccion"].ToString(),
                idREG = Convert.ToInt32(formCollection["inpRegion"]),
                idPRO = Convert.ToInt32(formCollection["inpProvincia"]),
                idCMN = Convert.ToInt32(formCollection["inpComuna"]),
            };

            br.ActualizarSucursal(branch);
            Response.Redirect("/Branches/EditBranch?id=" + branch.IdSUC);
        }
    }
}
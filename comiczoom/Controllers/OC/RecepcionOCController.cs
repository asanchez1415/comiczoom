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
    public class RecepcionOCController : Controller
    {
        OrdenesCompra oc = new OrdenesCompra();
        RecepcionOC reoc = new RecepcionOC();
        DRecepcionOC dreoc = new DRecepcionOC();
        StockInsumos si = new StockInsumos();

        // GET: RecepcionOC
        [Permissions.PermissionsRol(Rol.Administrador)]
        public ActionResult Reception()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int estado = Convert.ToInt32(Request.QueryString["est"]);

            ViewBag.idoc = id;
            ViewBag.estado = estado;

            return View();
        }

        [Permissions.PermissionsRol(Rol.Administrador)]
        public void InsertReception(FormCollection formCollection)
        {
            int idOC = Convert.ToInt32(formCollection["idoc"]);
            int idSUC = Convert.ToInt32(formCollection["idsuc"]);
            int idreoc = reoc.InsertarCabeceraRec(idOC);

            int contador = Convert.ToInt32(formCollection["contador"]);
            
            int estado = 0;
            int v = 0;
            for (int i = 1; i <= contador; i++)
            {
                int ins = Convert.ToInt32(formCollection[$"idins{i}"]);
                int can = Convert.ToInt32(formCollection[$"canrec{i}"]);
                int canOr = Convert.ToInt32(formCollection[$"cantoriginal{i}"]);

                dreoc.InsertarUnDetalleDeRO(ins, idreoc, can);
                si.SumarInsumo(idSUC,ins,can);

                int res = canOr - can;
                v += res;
            }

            if (v > 0)
            {
                estado = 1;
            }
            else
            {
                estado = 2;
            }

            oc.ActualizarEstado(idOC, estado);
       
            Response.Redirect("/RecepcionOC/Reception?id=" + idOC + "&est=" + estado);
        }
    }
}
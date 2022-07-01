using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba.Models;
using prueba.Models.Tiraje;

namespace prueba.Controllers.Tiraje
{
    [Authorize]
    public class RecepcionTirajeController : Controller
    {
        Tirajes t = new Tirajes();
        RecepcionTir rt = new RecepcionTir();
        DRecepcionTir drt = new DRecepcionTir();
        StockComics sc = new StockComics();

        // GET: RecepcionTiraje
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
            int idTIR = Convert.ToInt32(formCollection["idtir"]);
            int idSUC = Convert.ToInt32(formCollection["idSUC"]);
            int idretir = rt.InsertarCabeceraRec(idTIR);

            int contador = Convert.ToInt32(formCollection["contador"]);

            int estado = 0;
            int v = 0;
            for (int i = 1; i <= contador; i++)
            {
                int com = Convert.ToInt32(formCollection[$"idcom{i}"]);
                int can = Convert.ToInt32(formCollection[$"canrec{i}"]);
                int canOr = Convert.ToInt32(formCollection[$"cantoriginal{i}"]);

                drt.InsertarUnDetalleDeRTIR(com, idretir, can);
                sc.SumarComics(idSUC,com,can);

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

            t.ActualizarEstado(idTIR, estado);
            

            Response.Redirect("/RecepcionTiraje/Reception?id=" + idTIR + "&est=" + estado);
        }
    }
}
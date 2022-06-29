using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba.Controllers.OC
{
    public class RecepcionOCController : Controller
    {
        // GET: RecepcionOC
        public ActionResult Reception()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            int estado = Convert.ToInt32(Request.QueryString["est"]);

            ViewBag.idoc = id;
            ViewBag.estado = estado;

            return View();
        }
    }
}
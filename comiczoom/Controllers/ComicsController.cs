using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace prueba.Controllers
{
    [Authorize]
    public class ComicsController : Controller
    {
        // GET: Comics
        public ActionResult ComicsList()
        {

            return View();
        }
    }
}
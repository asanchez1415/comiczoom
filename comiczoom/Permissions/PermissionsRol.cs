using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Para la acción de permisos
using System.Web.Mvc;

namespace prueba.Permissions
{
    public class PermissionsRolAttribute : ActionFilterAttribute
    {
        private Rol idRol;

        public PermissionsRolAttribute(Rol _idRol)
        {
            idRol = _idRol;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Em"] != null)
            {
                UserLogin em = HttpContext.Current.Session["Em"] as UserLogin;

                if (em.IdRol != this.idRol)
                {
                    filterContext.Result = new RedirectResult("~/Home/NoAccess");
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
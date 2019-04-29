
namespace AsistenteMatricula.Portal.Security
{
    using Dominio;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using ReportesService;

    public class SecurityLocal
    { 
        public static UniversidadUsuario Usuario
        {
            get
            {
                try
                {
                    var inst = System.Web.HttpContext.Current.Session["SessionUsuario"];
                    if (inst == null)
                    {
                        HttpContext.Current.Response.StatusCode = 401;
                        return new UniversidadUsuario() { Correo = string.Empty };
                    }
                    else
                        return System.Web.HttpContext.Current.Session["SessionUsuario"] as AsistenteMatricula.Portal.ReportesService.UniversidadUsuario;
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.StatusCode = 401;
                    throw;
                }
            }
        }
        
        public static bool IsAuthenticated
        {
            get
            {
                return Convert.ToBoolean(HttpContext.Current.Session["SessionIsAuthenticated"]);
            }
        }
         
        public static void SignOut()
        {
            HttpContext.Current.Session["SessionUsuario"] = null;
            HttpContext.Current.Session["SessionIsAuthenticated"] = false;
        }
    }
}

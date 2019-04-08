using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AsistenteMatricula.Portal.Models;
using AsistenteMatricula.Portal.Security;
using System.ServiceModel;
using AsistenteMatricula.Portal.Errores;

namespace AsistenteMatricula.Portal.Controllers
{ 
    public class AccountController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Correo, string Contrasenia, string RUC)
        {
            try
            {


                var instLocal = new ReportesService.ReportesServiceClient().Autenticacion(RUC, Correo, Contrasenia);
                if (instLocal != null)
                {
                    System.Web.HttpContext.Current.Session["SessionIsAuthenticated"] = true;
                    System.Web.HttpContext.Current.Session["SessionUsuario"] = instLocal;
                    return Json("Success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Datos incorrectos", JsonRequestBehavior.AllowGet);
                }

            }
            catch (FaultException<RepetidoException> error)
            {
                //return Json("Error", JsonRequestBehavior.AllowGet);
                throw new Exception(error.Detail.Descripcion);
            } 
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            SecurityLocal.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
         

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
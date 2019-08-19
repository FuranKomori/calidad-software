using CalidadSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CalidadSoftware.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string message ="")
        {
            ViewBag.Message = message;
            return View();
        }
        
        public ActionResult Registrarse()
        {
            ViewBag.Title = "Registrarse";

            return View();
        }
        
        public ActionResult Ingresar()
        {
            ViewBag.Title = "Entrar";

            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string password)
        {

            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
            {
                Databases db = new Databases();
                var usuario = db.users.FirstOrDefault(e => e.user == user && e.password == password);
                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuario.user, true);
                    return RedirectToAction("Index", "Empleadoes");
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { message = "No encontramos tus datos" });
                }
            }
            else
            {
                return RedirectToAction("Index", "Home", new { message = "Llena los campos para poder iniciar sesión" });
            }    

            
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}

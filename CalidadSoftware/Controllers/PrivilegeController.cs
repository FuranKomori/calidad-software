using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using A11_RBS.Models;
using CalidadSoftware.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace CalidadSoftware.Controllers
{
    public class PrivilegeController : Controller
    {
        ApplicationDbContext context;
        
        public PrivilegeController()
        {
            context = new ApplicationDbContext();
        }


        // GET: Privilege
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Roles = new IdentityRole();
            return View(Roles);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
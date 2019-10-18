using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalidadSoftware.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;

namespace CalidadSoftware.Controllers
{
    public class PrivilegeController : Controller
    {
        IdentityDbContext context;
        
        public PrivilegeController()
        {
            context = new IdentityDbContext();
        }


        // GET: Privilege
        public ActionResult Index()
        {
            var Privileges = context.Roles.ToList();
            return View(Privileges);
        }

        public ActionResult Create()
        {
            var Privilege = new IdentityRole();
            return View(Privilege);
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
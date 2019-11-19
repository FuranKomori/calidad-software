using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Globalization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CalidadSoftware.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Database = CalidadSoftware.Models.Databases;
using A11_RBS.Models;

namespace CalidadSoftware.Controllers
{


    public class usersController : Controller
    {
        

    //    private ApplicationUserManager _userManager;
    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            if (_userManager == null && HttpContext == null)
    //            {
    //                return new ApplicationUserManager(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(db));
    //            }
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }

    //        ApplicationDbContext context;


    //    public usersController()
    //    {
    //        context = new ApplicationDbContext();
    //    }

    //    public usersController(ApplicationUserManager userManager)
    //    {
    //        UserManager = userManager;
    //    }

    //    public ApplicationUserManager UserManager
    //    {
    //        get
    //        {
    //            return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
    //        }
    //        private set
    //        {
    //            _userManager = value;
    //        }
    //    }

        private Database db = new Database();

        // GET: users
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: users/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            //ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
            return View();
        }

        // POST: users/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public async Task<ActionResult> Create([Bind(Include = "id_user,user,password,privilege_level")] users users)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.users.Add(users);
        //        db.SaveChanges();
        //        /*return RedirectToAction("Index");*/
        //        var user = new ApplicationUser { UserName = users.user };
        //        var result = await UserManager.CreateAsync(user, users.password);
        //        if (result.Succeeded)
        //        {

        //            //Assign Role to user Here 
        //            await this.UserManager.AddToRoleAsync(user.Id, users.Name);
        //            //Ends Here
                    

        //            return RedirectToAction("Index", "Home");
        //        }
        //    }

        //    ViewBag.Name = new SelectList(context.Roles.ToList(), "Name", "Name");
        //    return View();
        //}

        // GET: users/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,user,password,privilege_level")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: users/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

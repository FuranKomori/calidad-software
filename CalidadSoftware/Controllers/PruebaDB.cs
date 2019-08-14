using CalidadSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CalidadSoftware.Controllers
{
    public class PruebaDB : Controller
    {
        // GET: PruebaDB
        public ActionResult Index()
        {

            DataBase db = new DataBase();

            var listusuarios = db.users.ToList();

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = listusuarios
            };
        }
    }
}
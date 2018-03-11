using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XLTGoods.Models;

namespace XLTGoods.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProperty()
        {
            using (XLTDatabaseEntities dc = new XLTDatabaseEntities())
            {
                var property = dc.Property.OrderBy(a => a.PName).ToList();
                return Json(new { data = property }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
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
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (XLTDatabaseEntities dc = new XLTDatabaseEntities())
            {
                var v = dc.Property.Where(a => a.ProId == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Property prop)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (XLTDatabaseEntities dc = new XLTDatabaseEntities())
                {
                    if (prop.ProId > 0)
                    {
                        //Edit 
                        var v = dc.Property.Where(a => a.ProId == prop.ProId).FirstOrDefault();
                        if (v != null)
                        {
                            v.ProId = prop.ProId;
                            v.PName = prop.PName;
                            v.Brand = prop.Brand;
                            v.Number = prop.Number;
                            v.Model = prop.Model;
                            v.OneCategory = prop.OneCategory;
                            v.TwoCategory = prop.TwoCategory;
                           
                        }
                    }
                    else
                    {
                        //Save
                        dc.Property.Add(prop);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (XLTDatabaseEntities dc = new XLTDatabaseEntities())
            {
                var v = dc.Property.Where(a => a.ProId == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteProperty(int id)
        {
            bool status = false;
            using (XLTDatabaseEntities dc = new XLTDatabaseEntities())
            {
                var v = dc.Property.Where(a => a.ProId == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Property.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
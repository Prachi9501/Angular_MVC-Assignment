using ASPNET_MVC_Datatables.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNET_MVC_Datatables.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult loaddata()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var data = dc.QuestionAnswerLists.OrderBy(a => a.Questions).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.QuestionAnswerLists.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(QuestionAnswerList emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (emp.Id > 0)
                    {
                        //Edit 
                        var v = dc.QuestionAnswerLists.Where(a => a.Id == emp.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.Questions = emp.Questions;
                            v.Option1 = emp.Option1;
                            v.Option2 = emp.Option2;
                            v.Option3 = emp.Option3;
                            v.Option4 = emp.Option4;
                        }
                    }
                    else
                    {
                        //Save
                        dc.QuestionAnswerLists.Add(emp);
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
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.QuestionAnswerLists.Where(a => a.Id == id).FirstOrDefault();
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
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.QuestionAnswerLists.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.QuestionAnswerLists.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
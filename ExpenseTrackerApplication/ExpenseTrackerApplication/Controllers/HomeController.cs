using ExpenseTrackerApplication.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.catelist = getcategory();
            dy.explist = getexpenses();
            dy.shtitle = getitle(); 
            return View(dy);
        }

        public List<category> getcategory()
        {
            ExpenseTrakerAppEntities sd = new ExpenseTrakerAppEntities();
            List<category> lcat = sd.categories.ToList();
            return lcat;
        }

        public List<expense> getexpenses()
        {
            ExpenseTrakerAppEntities sd = new ExpenseTrakerAppEntities();
            List<expense> lexp = sd.expenses.ToList();
            return lexp;
        }

        public List<expense> getitle()
        {
            ExpenseTrakerAppEntities sd = new ExpenseTrakerAppEntities();
            List<expense> ltitle = sd.expenses.ToList();    
            return ltitle;
        }



        [HttpPost]
        public ActionResult Index(int exampleInputEmail1)
        {
            return Content("Form parameter - " + exampleInputEmail1);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
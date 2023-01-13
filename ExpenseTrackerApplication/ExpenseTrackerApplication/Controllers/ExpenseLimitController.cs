using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTrackerApplication.Controllers
{
    public class ExpenseLimitController : Controller
    {
        // GET: ExpenseLimit
        public ActionResult Index()
        {
            return View();
        }
    }
}
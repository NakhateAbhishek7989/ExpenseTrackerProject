using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpenseTrackerApplication.Models;

namespace ExpenseTrackerApplication.Controllers
{
    public class expensesController : Controller
    {
        private ExpenseTrakerAppEntities db = new ExpenseTrakerAppEntities();


        
        


        // GET: expenses
        public ActionResult Index()
        {
            var expenses = db.expenses.Include(e => e.category);
            return View(expenses.ToList());
        }

        // GET: expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expense expense = db.expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: expenses/Create
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.categories, "ID", "Category_Name");
            return View();
        }

        // POST: expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Amount,Category_ID,Date_Time")] expense expense)
        {
            if (ModelState.IsValid)
            {
                db.expenses.Add(expense);
                db.SaveChanges();
                TempData["AlertMessage"] = "Expense Has Been successfully Added";
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.categories, "ID", "Category_Name", expense.Category_ID);
            return View(expense);
        }

        // GET: expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expense expense = db.expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.categories, "ID", "Category_Name", expense.Category_ID);
            return View(expense);
        }

        // POST: expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Amount,Category_ID,Date_Time")] expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.categories, "ID", "Category_Name", expense.Category_ID);
            return View(expense);
        }

        // GET: expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            expense expense = db.expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            expense expense = db.expenses.Find(id);
            db.expenses.Remove(expense);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyTrashCollector.Models;

namespace MyTrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Email == userEmail);
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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


        [HttpGet]
        public ActionResult ChangeDay()
        {
            var userEmail = User.Identity.Name;
            var customer =
                db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Email == userEmail);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

         [HttpPost]
        public ActionResult ChangeDay(Address address)
         {
             var userEmail = User.Identity.Name;
             var customer =
                 db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Email == userEmail);

             customer.Day.PickUpDay = address.Day.PickUpDay;

             db.SaveChanges();
             return View("ConfirmDayChange", customer);
         }

        [HttpGet]
        public ActionResult SuspendService()
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Email == userEmail);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View("SuspendService", customer);
        }

        [HttpPost]
        public ActionResult SuspendService(Day day)
        {
            var userEmail = User.Identity.Name;
            var customer = db.Addresses.Include(a => a.Customer).Include(d => d.Day).Single(c => c.Customer.Email == userEmail);
            customer.Day.VacationStart = day.VacationStart.Value.Date;
            customer.Day.VacationEnd = day.VacationEnd.Value.Date;

            db.SaveChanges();
            return View("ConfirmSuspend", customer);
        }
        
    }
}

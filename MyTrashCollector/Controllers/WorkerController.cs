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
    public class WorkerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Worker
        public ActionResult Index()
        {
            var addresses = db.Addresses.Include(a => a.Customer).Include(a => a.Day);
            return View();
        }

        [HttpPost]

        public ActionResult WorkerRoute(Address routeZip)
        {
            //var pickUp = DateTime.Now.DayOfWeek.ToString();
            var pickUp = "Monday";
            var addresses = db.Addresses.Include(a => a.Customer).Include(a => a.Day).ToList();
            List<Address> pickUps = new List<Address>();
            foreach (Address address in addresses)
                if(address.ZipCode == routeZip.ZipCode && pickUp == address.Day.PickUpDay && address.IsActive)
            {
                pickUps.Add(address);
            }
            //return Content("Testing");
            return View(pickUps);
        }

        // GET: Worker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Worker/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName");
            ViewBag.DayID = new SelectList(db.Days, "Id", "PickUpDay");
            return View();
        }

        // POST: Worker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Street,ZipCode,IsActive,CustomerID,DayID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName", address.CustomerID);
            ViewBag.DayID = new SelectList(db.Days, "Id", "PickUpDay", address.DayID);
            return View(address);
        }

        // GET: Worker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName", address.CustomerID);
            ViewBag.DayID = new SelectList(db.Days, "Id", "PickUpDay", address.DayID);
            return View(address);
        }

        // POST: Worker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Street,ZipCode,IsActive,CustomerID,DayID")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "Id", "FirstName", address.CustomerID);
            ViewBag.DayID = new SelectList(db.Days, "Id", "PickUpDay", address.DayID);
            return View(address);
        }

        // GET: Worker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = db.Addresses.Find(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Worker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
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

        public ActionResult ShowMap()
        {
            
            return View("Map");
        }
        
    }
}

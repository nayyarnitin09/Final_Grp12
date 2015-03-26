using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectTeam12_Latest.Models;

namespace ProjectTeam12_Latest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarTypesController : Controller
    {
        private CarEntities db = new CarEntities();

        // GET: CarTypes
        public ActionResult Index()
        {
            return View(db.CarTypes.ToList());
        }

        // GET: CarTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType carType = db.CarTypes.Find(id);
            if (carType == null)
            {
                return HttpNotFound();
            }
            return View(carType);
        }

        // GET: CarTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsageType,UsageId")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                db.CarTypes.Add(carType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carType);
        }

        // GET: CarTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType carType = db.CarTypes.Find(id);
            if (carType == null)
            {
                return HttpNotFound();
            }
            return View(carType);
        }

        // POST: CarTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsageType,UsageId")] CarType carType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carType);
        }

        // GET: CarTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType carType = db.CarTypes.Find(id);
            if (carType == null)
            {
                return HttpNotFound();
            }
            return View(carType);
        }

        // POST: CarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarType carType = db.CarTypes.Find(id);
            db.CarTypes.Remove(carType);
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

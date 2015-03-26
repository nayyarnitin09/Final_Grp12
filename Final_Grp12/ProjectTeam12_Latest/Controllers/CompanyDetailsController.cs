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
    public class CompanyDetailsController : Controller
    {
        private CarEntities db = new CarEntities();

        // GET: CompanyDetails
        public ActionResult Index()
        {
            return View(db.CompanyDetails.ToList());
        }

        // GET: CompanyDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return HttpNotFound();
            }
            return View(companyDetail);
        }

        // GET: CompanyDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,CompanyName,HeadQuartersAt,NoOFEmployees,SetUpYear")] CompanyDetail companyDetail)
        {
            if (ModelState.IsValid)
            {
                db.CompanyDetails.Add(companyDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyDetail);
        }

        // GET: CompanyDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return HttpNotFound();
            }
            return View(companyDetail);
        }

        // POST: CompanyDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,CompanyName,HeadQuartersAt,NoOFEmployees,SetUpYear")] CompanyDetail companyDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyDetail);
        }

        // GET: CompanyDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            if (companyDetail == null)
            {
                return HttpNotFound();
            }
            return View(companyDetail);
        }

        // POST: CompanyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyDetail companyDetail = db.CompanyDetails.Find(id);
            db.CompanyDetails.Remove(companyDetail);
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

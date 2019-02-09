using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlowMonitoringInsp.DAL;
using FlowMonitoringInsp.Models;

namespace FlowMonitoringInsp.Controllers
{
    public class TelogController : Controller
    {
        private FlowMonitoringContext db = new FlowMonitoringContext();

        // GET: Telog
        public ActionResult Index()
        {
            return View(db.telogs.ToList());
        }

        // GET: Telog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telog telog = db.telogs.Find(id);
            if (telog == null)
            {
                return HttpNotFound();
            }
            return View(telog);
        }

        // GET: Telog/Create
        public ActionResult Create(int? number)
        {
            Models.Telog telog = new Models.Telog { SiteID = (int)number };
            return View("Create", telog);
        }

        // POST: Telog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelogID,TelogName,Modem,SiteID")] Telog telog)
        {
            if (ModelState.IsValid)
            {
                db.telogs.Add(telog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telog);
        }

        // GET: Telog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telog telog = db.telogs.Find(id);
            if (telog == null)
            {
                return HttpNotFound();
            }
            return View(telog);
        }

        // POST: Telog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelogID,TelogName,Modem,SiteID")] Telog telog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telog);
        }

        // GET: Telog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telog telog = db.telogs.Find(id);
            if (telog == null)
            {
                return HttpNotFound();
            }
            return View(telog);
        }

        // POST: Telog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telog telog = db.telogs.Find(id);
            db.telogs.Remove(telog);
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

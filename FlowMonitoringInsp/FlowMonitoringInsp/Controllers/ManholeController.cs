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
    public class ManholeController : Controller
    {
        private FlowMonitoringContext db = new FlowMonitoringContext();

        // GET: Manhole
        public ActionResult Index()
        {
            return View(db.manholes.ToList());
        }

        // GET: Manhole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manhole manhole = db.manholes.Find(id);
            if (manhole == null)
            {
                return HttpNotFound();
            }
            return View(manhole);
        }

        // GET: Manhole/Create
        public ActionResult Create(int? number)
        {
            //passing a manhole with the site for association.
            Models.Manhole manhole = new Models.Manhole { SiteID = (int)number};
            return View("Create",manhole);
        }

        // POST: Manhole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManholeID,ManholeName,HeavyTraffic,H2S,Oxygen,LEL,SiteID")] Manhole manhole)
        {
            if (ModelState.IsValid)
            {
                db.manholes.Add(manhole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manhole);
        }

        // GET: Manhole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manhole manhole = db.manholes.Find(id);
            if (manhole == null)
            {
                return HttpNotFound();
            }
            return View(manhole);
        }

        // POST: Manhole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManholeID,ManholeName,HeavyTraffic,H2S,Oxygen,LEL,SiteID")] Manhole manhole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manhole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manhole);
        }

        // GET: Manhole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manhole manhole = db.manholes.Find(id);
            if (manhole == null)
            {
                return HttpNotFound();
            }
            return View(manhole);
        }

        // POST: Manhole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manhole manhole = db.manholes.Find(id);
            db.manholes.Remove(manhole);
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

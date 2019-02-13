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
    public class FlowMeterController : Controller
    {
        private FlowMonitoringContext db = new FlowMonitoringContext();

        // GET: FlowMeter
        public ActionResult Index()
        {
            return View(db.flowMeters.ToList());
        }

        // GET: FlowMeter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowMeter flowMeter = db.flowMeters.Find(id);
            if (flowMeter == null)
            {
                return HttpNotFound();
            }
            return View(flowMeter);
        }

        // GET: FlowMeter/Create
        public ActionResult Create(int? number)
        {
            Models.FlowMeter flowMeter = new Models.FlowMeter { SiteId = (int)number };
            return View("Create", flowMeter);
        }

        // POST: FlowMeter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlowMeterModelID,FMModel,SerialNumber,SiteId")] FlowMeter flowMeter)
        {
            if (ModelState.IsValid)
            {
                db.flowMeters.Add(flowMeter);
                db.SaveChanges();
                return RedirectToRoute(new { controller = "Site", action = "SiteDetails", id = flowMeter.SiteId });
            }

            return View(flowMeter);
        }

        // GET: FlowMeter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowMeter flowMeter = db.flowMeters.Find(id);
            if (flowMeter == null)
            {
                return HttpNotFound();
            }
            return View(flowMeter);
        }

        // POST: FlowMeter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FlowMeterModelID,FMModel,SerialNumber,SiteId")] FlowMeter flowMeter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flowMeter).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToRoute(new { controller = "Site", action = "SiteDetails", id = flowMeter.SiteId });
            }
            return View(flowMeter);
        }

        // GET: FlowMeter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FlowMeter flowMeter = db.flowMeters.Find(id);
            if (flowMeter == null)
            {
                return HttpNotFound();
            }
            return View(flowMeter);
        }

        // POST: FlowMeter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FlowMeter flowMeter = db.flowMeters.Find(id);
            db.flowMeters.Remove(flowMeter);
            db.SaveChanges();
            return RedirectToRoute(new { controller = "Site", action = "SiteDetails", id = flowMeter.SiteId });
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

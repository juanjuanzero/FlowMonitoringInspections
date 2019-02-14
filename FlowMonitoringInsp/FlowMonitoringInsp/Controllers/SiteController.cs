using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowMonitoringInsp.Controllers
{
    public class SiteController : Controller
    {

        private FlowMonitoringInsp.DAL.FlowMonitoringContext database = new DAL.FlowMonitoringContext();

        // GET: Site
        public ActionResult Index()
        {
            //get all of the flow meters sites in a list
            var _sites = database.sites.ToList();
            return View("AllSites", _sites);
        }

        //DETAILS Action Method, shows the manhole, flow meters and sites associated to the site
        public ActionResult SiteDetails(int? id)
        {
            //gets the details of the site and displays it on the screen, view provides a way to make edits to the equipment.
            if (id != null)
            {
                //make queries to db
                IEnumerable<Models.FlowMeter> _flowmeters = database.flowMeters.Where(m => m.SiteId == id);
                IEnumerable<Models.Sensor> _sensors = database.Sensors.Where(m => m.SiteID == id);
                IEnumerable<Models.Telog> _telogs = database.telogs.Where(m => m.SiteID == id);
                Models.Manhole manhole = database.manholes.Where(m => m.SiteID == id).FirstOrDefault();

                string _sitename = database.sites.Where(m => m.SiteID == id).FirstOrDefault().SiteDisplayName;

                var _site = new Models.SiteView
                {
                    //find the flow meters associated to the site.
                    SiteID = (int)id,
                    SiteFlowMeters = _flowmeters,
                    SiteSensors = _sensors,
                    SiteTelogs = _telogs,
                    SiteManhole = manhole,
                    SiteDisplayName = _sitename
                };

                ViewBag.SiteName = _sitename;

                return View("SiteEquipment", _site);
            }
            else
            {
                //return error view. need to make error view
                return View("Error");
            }


        }

        //EDIT Action Method, when called takes the id of the item and populates the view model
        public ActionResult SiteEdit(int? id)
        {
            Models.Site _site = database.sites.Where(m => m.SiteID == id).FirstOrDefault();

            return View("SiteEdit", _site);
        }

        //EDIT Post receiver where MVC passes in a model from the form
        [HttpPost]
        public ActionResult SiteEdit(Models.Site _site)
        {
            if (ModelState.IsValid)
            {
                //set the entry of the model passed in as an entity and let the db know it has been modified.
                database.Entry(_site).State = System.Data.Entity.EntityState.Modified;
                database.SaveChanges();

                return Index();
            }
            //if model state was not valid, call the edit view again.
            return View("SiteEdit",_site );
        }

        public ActionResult SiteAdd()
        {
            Models.Site _site = new Models.Site();
            return View("SiteEdit", _site);
        }

        [HttpPost]
        public ActionResult SiteAdd(Models.Site _site)
        {
            
            //create a new site
            Models.Site _addSite = new Models.Site()
            {
                //by setting the model attirbutes manually, we are preventing over-posting an alternative way is to use the BindAttribute 
                Address = _site.Address,
                SiteFlowMeterIDs = _site.SiteFlowMeterIDs,
                SiteSensorIDs = _site.SiteSensorIDs,
                SiteTelogID = _site.SiteTelogID
            };

            database.sites.Add(_addSite);
            database.SaveChanges();

            //when adding go back to the list
            var _sites = database.sites.ToList();
            return View("AllSites", _sites);
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                //calling the delete from the All Sites view will pass in the id of the iste
                Models.Site _site = database.sites.Find(id);
                //return the delete confirmation page
                return View("Delete", _site);
            }

            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Models.Site site)
        {
            if (ModelState.IsValid)
            {
                //removed the site from the db
                Models.Site _site = database.sites.Find((int)site.SiteID);
                database.sites.Remove(_site);
                database.SaveChanges();

                //also remove equipment that has this assigned.
                IEnumerable<Models.FlowMeter> _flowmeters = database.flowMeters.Where(m => m.SiteId == site.SiteID);
                IEnumerable<Models.Sensor> _sensors = database.Sensors.Where(m => m.SiteID == site.SiteID);
                IEnumerable<Models.Telog> _telogs = database.telogs.Where(m => m.SiteID == site.SiteID);
                Models.Manhole manhole = database.manholes.Where(m => m.SiteID == site.SiteID).FirstOrDefault();

                foreach (var f in _flowmeters)
                {
                    Models.FlowMeter flowMeter = database.flowMeters.Find(f.ID);
                    database.flowMeters.Remove(flowMeter);
                }
                database.SaveChanges();

                foreach (var s in _sensors)
                {
                    Models.Sensor sensor = database.Sensors.Find(s.ID);
                    database.Sensors.Remove(sensor);
                }
                database.SaveChanges();

                foreach (var t in _telogs)
                {
                    Models.Telog telog = database.telogs.Find(t.TelogID);
                    database.telogs.Remove(telog);
                }
                database.SaveChanges();

                Models.Manhole mh = database.manholes.Find(manhole.ManholeID);
                database.manholes.Remove(mh);
                database.SaveChanges();

                return RedirectToAction("Index");
            }

            return View("Delete", site);
        }


    }
}
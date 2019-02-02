using FlowMonitoringInsp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowMonitoringInsp.Controllers
{
    public class FlowMeterController : Controller
    {
        private FlowMonitoringContext database = new FlowMonitoringContext();

        // GET: FlowMeter
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
            if(id != null)
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
                    SiteFlowMeters = _flowmeters,
                    SiteSensors = _sensors,
                    SiteTelogs = _telogs,
                    SiteManhole = manhole,
                    SiteDisplayName = _sitename
                };

                return View("SiteEquipment", _site);
            }
            else {
                return View();
            }

            
        }

        //EDIT Action Method

        //DELETE Action Method

        //Dispose Method?
    }
}
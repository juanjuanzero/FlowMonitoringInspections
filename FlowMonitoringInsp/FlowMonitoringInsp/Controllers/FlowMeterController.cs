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
            if(id != null)
            {
                IEnumerable<Models.FlowMeter> _flowmeters = database.flowMeters.Where(m => m.SiteId == id);
                IEnumerable<Models.Sensor> _sensors = database.Sensors.Where(m => m.SiteID == id);
                IEnumerable<Models.Telog> _telogs = database.telogs.Where(m => m.SiteID == id);

                var _site = new Models.Site
                {
                    //find the flow meters associated to the site.
                    SiteFlowMeters = _flowmeters,
                    SiteSensors = _sensors,
                    SiteTelogs = _telogs
                };

                return View("SiteDetail", _site);
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
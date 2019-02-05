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

        // GET: Site
        public ActionResult Index()
        {
            return View();
        }


        //DELETE Action Method

        //Dispose Method?
    }
}
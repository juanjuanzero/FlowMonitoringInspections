using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowMonitoringInsp.Controllers
{
    public class FlowMeterController : Controller
    {
        // GET: FlowMeter
        public ActionResult Index()
        {
            //get all of the flow meters in a list
            return View();
        }

        //ADD Action Method
        public ActionResult Create()
        {

            return View();
        }

        //EDIT Action Method

        //DELETE Action Method

        //Dispose Method?
    }
}
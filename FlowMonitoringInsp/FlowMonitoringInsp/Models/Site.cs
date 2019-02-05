using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class Site
    {
        [Key]
        public int SiteID { get; set; }
        
        //list of ids will be passed into view model and constructed by site detail
        public List<int> SiteFlowMeterIDs {get; set; }
        public List<int> SiteSensorIDs { get; set; }

        //properties for display purposes, but how would it get these values?
        public int SiteTelogID { get; set; }
        public string Address { get; set; }

        public string SiteDisplayName
        {
            get{ return SiteTelogID.ToString() + " at " + Address; }
        }
    }
}
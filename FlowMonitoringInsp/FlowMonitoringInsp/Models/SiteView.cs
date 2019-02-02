using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class SiteView
    {
        [Key]
        public int SiteID { get; set; }
        public string SiteDisplayName { get; set; }
        public IEnumerable<Models.Telog> SiteTelogs { get; set; }
        public IEnumerable<Models.FlowMeter> SiteFlowMeters { get; set; }
        public IEnumerable<Models.Sensor> SiteSensors { get; set; }
        public Models.Manhole SiteManhole { get; set; }
    }
}
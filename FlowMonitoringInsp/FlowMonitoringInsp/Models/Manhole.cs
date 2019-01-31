using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class Manhole
    {
        [Key]
        public int ID { get; set; } //id for db
        public string ManholeID { get; set; }
        public bool HeavyTraffic { get; set; }
        public float H2S { get; set; }
        public float Oxygen { get; set; }
        public float LEL { get; set; }
        public int SiteID { get; set; }
    }
} 
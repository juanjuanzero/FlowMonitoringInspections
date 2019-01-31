using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowMonitoringInsp.Models
{
    public class FlowMeter
    {
        public enum FM_model { Hach, ISCO, Telog, Other}

        [Key]
        public int ID { get; set; } //Id for db
        public int FlowMeterModelID { get; set; }
        public FM_model FMModel { get; set; }
        public int SerialNumber { get; set; }
        public int SiteId { get; set; }
    }
}
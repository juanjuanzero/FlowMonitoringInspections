using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlowMonitoringInsp.Models
{
    public class FlowMeterModel
    {
        public enum FM_model { Hach, ISCO, Telog, Other}

        [Key]
        public int FlowMeterModelID { get; set; }
        public FM_model FMModel { get; set; }
        public int SerialNumber { get; set; }
    }
}
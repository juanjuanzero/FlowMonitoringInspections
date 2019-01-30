using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class Telog
    {
        [Key]
        public int ID { get; set; }
        public int TelogID { get; set; }
        public string Modem { get; set; }
    }
}
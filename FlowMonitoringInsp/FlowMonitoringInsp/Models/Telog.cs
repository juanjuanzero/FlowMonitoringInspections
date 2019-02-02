﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class Telog
    {
        
        //public int ID { get; set; }

        [Key]
        public int TelogID { get; set; }
        public string TelogName { get; set; }
        public string Modem { get; set; }
        public int SiteID { get; set; }
    }
}
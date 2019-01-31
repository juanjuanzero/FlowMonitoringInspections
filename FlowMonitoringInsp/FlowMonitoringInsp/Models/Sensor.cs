using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowMonitoringInsp.Models
{
    public class Sensor
    {
        public enum SensorType
        {
            AreaVelocity,
            Level,
            Lazer
        }

        [Key]
        public int ID { get; set; }
        public string SensorSerialNum { get; set; }
        public SensorType Sensor_Type { get; set; }
        public int SiteID { get; set; }
    }
}
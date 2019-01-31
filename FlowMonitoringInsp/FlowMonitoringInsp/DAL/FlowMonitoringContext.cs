using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlowMonitoringInsp.DAL
{
    public class FlowMonitoringContext : DbContext
    {
        //adding an dbcontext after loading EF into the project.
        public DbSet<Models.FlowMeter> flowMeters { get; set; }
        public DbSet<Models.Manhole> manholes { get; set; }
        public DbSet<Models.Sensor> Sensors { get; set; }
        public DbSet<Models.Telog> telogs { get; set; }
        public DbSet<Models.Site> sites { get; set; }
    }
}
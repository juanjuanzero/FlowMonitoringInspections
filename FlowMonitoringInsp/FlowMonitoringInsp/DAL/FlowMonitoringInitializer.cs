using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FlowMonitoringInsp.DAL
{
    public class FlowMonitoringInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FlowMonitoringContext>
    {
        //this class inherits from the Flow Monitoring Context to be able to know if there are changes in the context

        //Seed the databse for testing
        protected override void Seed(FlowMonitoringContext context)
        {
            //base.Seed(context);

            var _flowMeters = new List<Models.FlowMeter>
            {
                new Models.FlowMeter
                {
                    ID = 1,
                    FlowMeterModelID = 1111,
                    SerialNumber = 2342342,
                    FMModel = Models.FlowMeter.FM_model.Hach,
                    SiteId = 1
                },
                new Models.FlowMeter
                {
                    ID = 2,
                    FlowMeterModelID = 2222,
                    SerialNumber = 2342342,
                    FMModel = Models.FlowMeter.FM_model.Hach,
                    SiteId = 2
                },
                new Models.FlowMeter
                {
                    ID = 3,
                    FlowMeterModelID = 3333,
                    SerialNumber = 516515,
                    FMModel = Models.FlowMeter.FM_model.ISCO,
                    SiteId = 3
                }
            };

            foreach (var item in _flowMeters)
            {
                context.flowMeters.Add(item);
            }

            context.SaveChanges();

            var _manholes = new List<Models.Manhole>
            {
                new Models.Manhole
                {
                    ID = 1,
                    ManholeID = "MH0001",
                    H2S = 10,
                    HeavyTraffic = true,
                    LEL = 12,
                    Oxygen = 100,
                    SiteID = 1
                },
                new Models.Manhole
                {
                    ID = 2,
                    ManholeID = "MH0002",
                    H2S = 10,
                    HeavyTraffic = true,
                    LEL = 16,
                    Oxygen = 100,
                    SiteID = 3
                },
                new Models.Manhole
                {
                    ID = 3,
                    ManholeID = "MH0003",
                    H2S = 11,
                    HeavyTraffic = true,
                    LEL = 15,
                    Oxygen = 150,
                    SiteID = 2
                }
            };

            _manholes.ForEach(m => context.manholes.Add(m));
            context.SaveChanges();

            var _sensor = new List<Models.Sensor>
            {
                new Models.Sensor
                {
                    ID = 1,
                    SiteID = 1,
                    SensorSerialNum = "SN1234",
                    Sensor_Type = Models.Sensor.SensorType.AreaVelocity
                },
                new Models.Sensor
                {
                    ID = 2,
                    SiteID = 3,
                    SensorSerialNum = "SN5678",
                    Sensor_Type = Models.Sensor.SensorType.Level
                },
                new Models.Sensor
                {
                    ID = 3,
                    SiteID = 3,
                    SensorSerialNum = "SN91011",
                    Sensor_Type = Models.Sensor.SensorType.Lazer
                }
            };

            _sensor.ForEach(m => context.Sensors.Add(m));
            context.SaveChanges();

            var _telog = new List<Models.Telog>
            {
                new Models.Telog
                {
                    ID = 1,
                    Modem = "LTE",
                    SiteID = 1,
                    TelogID = 1234
                },
                new Models.Telog
                {
                    ID = 2,
                    Modem = "Prepaid",
                    SiteID = 2,
                    TelogID = 5678
                }
            };

            _telog.ForEach(m => context.telogs.Add(m));
            context.SaveChanges();

            //make sure to modify the webconfig file

            var _site = new List<Models.Site>
            {
                new Models.Site
                {
                    SiteID = 1,
                    ManholeID = 1
                },
                new Models.Site
                {
                    SiteID = 2,
                    ManholeID = 3
                }
            };

            _site.ForEach(m => context.sites.Add(m));
            context.SaveChanges();
        }
    }
}
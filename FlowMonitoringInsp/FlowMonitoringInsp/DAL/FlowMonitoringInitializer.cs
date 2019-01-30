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
                    FMModel = Models.FlowMeter.FM_model.Hach
                },
                new Models.FlowMeter
                {
                    ID = 2,
                    FlowMeterModelID = 2222,
                    SerialNumber = 2342342,
                    FMModel = Models.FlowMeter.FM_model.Hach
                },
                new Models.FlowMeter
                {
                    ID = 3,
                    FlowMeterModelID = 3333,
                    SerialNumber = 516515,
                    FMModel = Models.FlowMeter.FM_model.ISCO
                }
            };

            foreach (var item in _flowMeters)
            {
                context.flowMeters.Add(item);
            }

            context.SaveChanges();

            //make sure to modify the webconfig file
        }
    }
}
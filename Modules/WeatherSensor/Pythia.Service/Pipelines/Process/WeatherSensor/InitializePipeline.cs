using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Service.Pipelines.Process.WeatherSensor
{
    public class InitializePipeline : IWeatherSensor
    {
        public void Process(WeatherSensorArgs args)
        {
            //perform base initialization
            if (args.Data.Any())
            {
                int rowsEmpty = 0;
                foreach (var value in args.Data)
                {
                    if (value.Altitude == String.Empty
                     && value.Humidity == String.Empty
                     && value.Pressure == String.Empty
                     && value.SensorId == String.Empty)
                        rowsEmpty++;
                }
                if (rowsEmpty == args.Data.Count)
                {
                    //all rows are empty, do not proceed
                    args.Abort = true;
                    args.Message += "all rows of data were missing or empty";
                }
                else
                {
                    try
                    {
                        args.WeatherService = new Service.WeatherSensor.WeatherSensorService();
                        args.WeatherService.Initialize(args.ConnectionString);
                    }
                    catch (Exception ex)
                    {
                        args.Abort = true;
                        args.Message += "there was an issue when connecting to mogoDB, " + ex.ToString();
                    }
                }
            }


        }
    }
}

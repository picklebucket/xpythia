using WS.Models.WeatherSensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Service.Pipelines.Process.WeatherSensor
{
    public class SaveDataToDatabase : IWeatherSensor
    {
        public void Process(WeatherSensorArgs args)
        {
            //save the dataset to the database in mongoDB
            if (args.Abort != true)
            {
                try
                {
                    foreach (var value in args.Data)
                    {
                        WeatherSensorModel model = new WeatherSensorModel
                        {
                            Altitude = value.Altitude,
                            Humidity = value.Humidity,
                            Pressure = value.Pressure,
                            SensorId = value.SensorId,
                            Temp = value.Temp,
                            ReadingDate = value.ReadingDate
                        };
                        args.WeatherService.Create(model);
                    }
                   
                }
                catch (Exception ex)
                {
                    args.Abort = true;
                    args.Message += "There was an issue saving the readings to the database" + ex.ToString();
                }
            }
        }
    }
}

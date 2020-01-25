using WS.Models.WeatherSensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;


namespace WS.Service.WeatherSensor
{
    public interface IWeatherSensorService
    {
        WeatherSensorModel Create(WeatherSensorModel reading);
    }
}

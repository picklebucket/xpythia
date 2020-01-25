using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Service.Pipelines.Process.WeatherSensor
{
    public interface IWeatherSensor 
    {
        void Process(WeatherSensorArgs args);
    }
}

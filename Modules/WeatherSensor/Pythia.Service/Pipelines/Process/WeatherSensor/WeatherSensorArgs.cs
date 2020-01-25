using WS.Models.WeatherSensor;
using WS.Service.WeatherSensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Service.Pipelines.Process.WeatherSensor
{
    public class WeatherSensorArgs : PipelineArgs
    {
        public List<SensorReadingModel> Data { get; set; }
        public List<WeatherSensorModel> ProcessedData { get; set; }
        public WeatherSensorService WeatherService { get; set; }
        public string ConnectionString { get; set; }
        public string MyProperty { get; set; }

    }
}

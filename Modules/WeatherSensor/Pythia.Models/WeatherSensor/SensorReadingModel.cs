using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WS.Models.WeatherSensor
{
    public class SensorReadingModel
    {

        public string SensorId { get; set; }

        public string Temp { get; set; }

        public string Humidity { get; set; }

        public string Pressure { get; set; }

        public string Altitude { get; set; }

        public DateTime ReadingDate { get; set; }
    }
}

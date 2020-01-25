using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WS.Models.WeatherSensor
{
    public class WeatherSensorModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("SensorId")]
        public string SensorId { get; set; }
        [BsonElement("Temp")]
        public string Temp { get; set; }
        [BsonElement("Humidity")]
        public string Humidity { get; set; }
        [BsonElement("Pressure")]
        public string Pressure { get; set; }
        [BsonElement("Altitude")]
        public string Altitude { get; set; }
        [BsonElement("ReadingDate")]
        public DateTime ReadingDate { get; set; }
    }
}



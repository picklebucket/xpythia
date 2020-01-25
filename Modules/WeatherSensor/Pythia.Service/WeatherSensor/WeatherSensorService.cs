using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WS.Models.WeatherSensor;

namespace WS.Service.WeatherSensor
{
    public class WeatherSensorService : IWeatherSensorService
    {
        private IMongoCollection<WeatherSensorModel> _weatherSensorModel;
        private string _connection;
        //public WeatherSensorService()
        //{
        //    //TODO: need to update this to get the setting from the config and not be hard coded

            
        //}
        public WeatherSensorService()
        {
            
        }

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("WeatherSensor");
            _weatherSensorModel = database.GetCollection<WeatherSensorModel>("WeatherSensor");
        }
        public WeatherSensorModel Create(WeatherSensorModel reading)
        {
            _weatherSensorModel.InsertOne(reading);
            return reading;
        }
    }
}

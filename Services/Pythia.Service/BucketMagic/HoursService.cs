using MongoDB.Bson;
using MongoDB.Driver;
using Pythia.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythia.Service.BucketMagic
{
    public class HoursService : IHoursService
    {
        private IMongoCollection<HoursModel> _hoursModel;
        private string _connection;
        //public WeatherSensorService()
        //{
        //    //TODO: need to update this to get the setting from the config and not be hard coded


        //}
        public HoursService()
        {

        }

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _hoursModel = database.GetCollection<HoursModel>("Hours_CI");
        }
        public HoursModel GetAll(HoursModel data)
        {
            //_weatherSensorModel.InsertOne(data);
            return data;
        }

        public List<HoursModel> GetByDateRange(DateTime minDate, DateTime maxDate)
        {
            //_weatherSensorModel.InsertOne(data);
            var dateFilter = Builders<HoursModel>.Filter;
            var min = minDate;
            var max = maxDate;

            var filter = dateFilter.Gte(x => x.Date, new BsonDateTime(min)) &
                         dateFilter.Lte(x => x.Date, new BsonDateTime(max));
            List<HoursModel> data = _hoursModel.Find(filter).ToList();
            return data;
        }

        public bool SetByResource(HoursModel data)
        {
            bool isSuccess = false;

            try
            {
                _hoursModel.InsertOne(data);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                //TODO: add error handling 
                isSuccess = false;
            }


            return isSuccess;
        }
       
    }
}

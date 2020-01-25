using MongoDB.Driver;
using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public class ResourcesService : IResourcesService
    {
        private IMongoCollection<ResourcesModel> _resourcesModel;
        private string _connection;

        public ResourcesService()
        {

        }
        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _resourcesModel = database.GetCollection<ResourcesModel>("Resources_CI");
        }

        public List<ResourcesModel> GetActiveResourceTable()
        {
            List<ResourcesModel> retVal = new List<ResourcesModel>();

            var isActiveFilter = Builders<ResourcesModel>.Filter;

            try
            {
                var filter = isActiveFilter.Eq(x => x.IsCurrent, true);
                return _resourcesModel.Find(filter).ToList();

            }
            catch (Exception ex)
            {
                //TODO: some error handling here
                return retVal;
            }
           
        }
    }
}

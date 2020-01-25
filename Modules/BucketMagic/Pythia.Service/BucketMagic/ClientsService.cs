using BM.Models.BucketMagic;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public class ClientsService : IClientsService
    {
        private IMongoCollection<ClientsModel> _clientsModel;
        private string _connection;

        public ClientsModel Create(ClientsModel data)
        {
            _clientsModel.InsertOne(data);
            return data;
        }

        public void Delete(string id)
        {
            _clientsModel.DeleteOne(a => a.Id == id);
        }

        public ClientsModel GetById(string id)
        {
            return _clientsModel.Find(document => document.Id == id).FirstOrDefault();
        }

        public ClientsModel GetByName(string name)
        {
            return _clientsModel.Find(document => document.Name == name).FirstOrDefault();
        }

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _clientsModel = database.GetCollection<ClientsModel>("Clients_CI");
        }

        public void UpdateById(string id, ClientsModel model)
        {
            _clientsModel.ReplaceOne(expense => expense.Id == id, model);
        }
    }
}

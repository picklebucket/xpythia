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
    public class PersonnelService : IPersonnelService
    {
        private IMongoCollection<PersonnelModel> _personnelModel;
        private string _connection;

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _personnelModel = database.GetCollection<PersonnelModel>("Personnel_CI");
        }

        public PersonnelModel CreatePerson(PersonnelModel model)
        {
            _personnelModel.InsertOne(model);
            return model;
        }

        public void DeleteById(string id)
        {
            _personnelModel.DeleteOne(a => a.Id == id);
        }

        public PersonnelModel GetById(string id)
        {
            return _personnelModel.Find(document => document.Id == id).FirstOrDefault();
        }

        public List<PersonnelModel> GetByIsActive(bool isActive)
        {
            return _personnelModel.Find(document => document.IsActive == isActive).ToList();
        }

        public PersonnelModel GetByName(string name)
        {
            return _personnelModel.Find(document => document.Name == name).FirstOrDefault();
        }

        public List<PersonnelModel> GetByStartDate(DateTime startDate)
        {
            return _personnelModel.Find(document => document.StartDate == startDate).ToList();
        }

        public void UpdateById(string id, PersonnelModel model)
        {
            _personnelModel.ReplaceOne(expense => expense.Id == id, model);
        }
    }
}

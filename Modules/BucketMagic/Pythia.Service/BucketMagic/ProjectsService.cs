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
    public class ProjectsService : IProjectsService
    {
        private IMongoCollection<ProjectsModel> _projectsModel;
        private IMongoCollection<ClientsModel> _clientsModel;
        private string _connection;

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _projectsModel = database.GetCollection<ProjectsModel>("Projects_CI");
            _clientsModel = database.GetCollection<ClientsModel>("Clients_CI");
        }

        public ProjectsModel Create(ProjectsModel data)
        {
            _projectsModel.InsertOne(data);
            return data;
        }

        public void Delete(string id)
        {
            _projectsModel.DeleteOne(a => a.Id == id);
        }

        public List<ProjectsModel> GetByClientId(string clientId)
        {
            return _clientsModel.Find(document => document.Id == clientId).FirstOrDefault().Projects.ToList();
        }


        public ProjectsModel GetById(string id)
        {
            return _projectsModel.Find(document => document.Id == id).FirstOrDefault();
        }

        public List<ProjectsModel> GetByStartDate(DateTime startDate)
        {
            return _projectsModel.Find(document => document.StartDate == startDate).ToList();
        }

        public bool SetByResource(ProjectsModel data)
        {
            bool isSuccess = false;

            try
            {
                _projectsModel.InsertOne(data);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                //TODO: add error handling 
                isSuccess = false;
            }

            return isSuccess;
        }

        public void UpdateById(string id, ProjectsModel data)
        {
            _projectsModel.ReplaceOne(expense => expense.Id == id, data);
        }
    }
}

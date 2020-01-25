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
    public class PaymentsService : IPaymentsService
    {
        private IMongoCollection<PaymentsModel> _paymentsModel;
        private string _connection;

        public void DeleteById(string id)
        {
            _paymentsModel.DeleteOne(a => a.Id == id);
        }

        public List<PaymentsModel> GetByClient(ClientsModel client)
        {
            return _paymentsModel.Find(document => document.Client == client).ToList();
        }

        public List<PaymentsModel> GetByDateRange(DateTime minDate, DateTime maxDate)
        {
            throw new NotImplementedException();
        }

        public PaymentsModel GetById(string id)
        {
            return _paymentsModel.Find(document => document.Id == id).FirstOrDefault();
        }

        public List<PaymentsModel> GetByNotPaidDateRange(DateTime minDate, DateTime maxDate)
        {
            var dateFilter = Builders<PaymentsModel>.Filter;
            var min = minDate;
            var max = maxDate;

            var filter = dateFilter.Gte(x => x.DatePaid, new BsonDateTime(min)) &
                         dateFilter.Lte(x => x.DatePaid, new BsonDateTime(max));

            return _paymentsModel.Find(filter).ToList();
        }

        public List<PaymentsModel> GetByProject(ProjectsModel project)
        {
            return _paymentsModel.Find(document => document.Project == project).ToList();
        }

        public List<PaymentsModel> GetBySentDateRange(DateTime minDate, DateTime maxDate)
        {
            var dateFilter = Builders<PaymentsModel>.Filter;
            var min = minDate;
            var max = maxDate;

            var filter = dateFilter.Gte(x => x.DateSent, new BsonDateTime(min)) &
                         dateFilter.Lte(x => x.DateSent, new BsonDateTime(max));

            return _paymentsModel.Find(filter).ToList();
        }

        public List<PaymentsModel> GetBySentDateRange(DateTime dateSent)
        {
            throw new NotImplementedException();
        }

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _paymentsModel = database.GetCollection<PaymentsModel>("Payments_CI");
        }

        public bool SetByResource(PaymentsModel data)
        {
            throw new NotImplementedException();
        }

        public void SetPaymentById(PaymentsModel data, string paymentId)
        {
            data.Id = new ObjectId(paymentId).ToString();
            _paymentsModel.InsertOne(data);
        }

        public void UpdateById(PaymentsModel data, string projectId)
        {
            _paymentsModel.ReplaceOne(document => document.Id == projectId, data);
        }

        void IPaymentsService.GetByClient(ClientsModel client)
        {
            throw new NotImplementedException();
        }

        void IPaymentsService.GetByProject(ProjectsModel project)
        {
            throw new NotImplementedException();
        }
    }
}

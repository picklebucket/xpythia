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
    public class ExpensesService : IExpensesService
    {
        private IMongoCollection<ExpensesModel> _expensesModel;
        private string _connection;

        public void Initialize(string connectionsString)
        {
            _connection = connectionsString;
            var client = new MongoClient(_connection);
            var database = client.GetDatabase("BucketMagic_CI");//conn string and db name should be pulling from config file 
            _expensesModel = database.GetCollection<ExpensesModel>("Expenses_CI");
        }

        public ExpensesModel Create(ExpensesModel model)
        {
            _expensesModel.InsertOne(model);
            return model;
        }

        public void Delete(string id)
        {
            _expensesModel.DeleteOne(a => a.Id == id);
        }

        public List<ExpensesModel> GetByDateRange(DateTime minDate, DateTime maxDate)
        {
            var dateFilter = Builders<ExpensesModel>.Filter;
            var min = minDate;
            var max = maxDate;

            var filter = dateFilter.Gte(x => x.Date, new BsonDateTime(min)) &
                         dateFilter.Lte(x => x.Date, new BsonDateTime(max));
            return _expensesModel.Find(filter).ToList();
        }

        public ExpensesModel GetById(string id)
        {
           return _expensesModel.Find(document => document.Id == id).FirstOrDefault();
        }

        public ExpensesModel GetByType(TaxCategory type)
        {
            return _expensesModel.Find(document => document.TaxCategory == type).FirstOrDefault();
        }

        public void UpdateById(string id, ExpensesModel model)
        {
            _expensesModel.ReplaceOne(expense => expense.Id == id, model);
        }
    }
}

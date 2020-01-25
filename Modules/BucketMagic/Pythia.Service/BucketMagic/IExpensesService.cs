using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IExpensesService
    {
        ExpensesModel GetById(string id);
        ExpensesModel GetByType(TaxCategory type);
        List<ExpensesModel> GetByDateRange(DateTime minDate, DateTime maxDate);
        ExpensesModel Create(ExpensesModel model);
        void UpdateById(string id, ExpensesModel model);
        void Delete(string id);
        void Initialize(string connectionsString);
    }
}

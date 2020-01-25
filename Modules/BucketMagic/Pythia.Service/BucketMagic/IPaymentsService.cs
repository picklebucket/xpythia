using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IPaymentsService
    {
        void Initialize(string connectionsString);
        List<PaymentsModel> GetByDateRange(DateTime minDate, DateTime maxDate);
        bool SetByResource(PaymentsModel data);
        PaymentsModel GetById(string id);
        void GetByClient(ClientsModel client);
        void GetByProject(ProjectsModel project);
        List<PaymentsModel> GetByNotPaidDateRange(DateTime minDate, DateTime maxDate);
        List<PaymentsModel> GetBySentDateRange(DateTime dateSent);
        void SetPaymentById(PaymentsModel data, string paymentId);
        void UpdateById(PaymentsModel data, string projectId);
        void DeleteById(string id);
    }
}

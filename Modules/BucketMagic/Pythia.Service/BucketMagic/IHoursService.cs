using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IHoursService
    {
        void Initialize(string connectionsString);
        List<HoursModel> GetByDateRange(DateTime minDate, DateTime maxDate);
        void SetDataSingle(HoursModel data);
        void SetDataMultiple(IEnumerable<HoursModel> data);
        bool SetByResource(HoursModel data);
    }
}

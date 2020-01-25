using Pythia.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythia.Service.BucketMagic
{
    public interface IHoursService
    {
        void Initialize(string connectionsString);
        List<HoursModel> GetByDateRange(DateTime minDate, DateTime maxDate);
        bool SetByResource(HoursModel data);
    }
}

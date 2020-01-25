using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class GetDataByDate : IBucketMagic
    {
        public void Process(BucketMagicArgs args)
        {
            //connect to mongoDB
            if (args.HoursService != null && args.Abort != true)
            {
                args.Data = args.HoursService.GetByDateRange(args.MinDate, args.MaxDate);
                //get data by set date
            }
            else
                args.Abort = true;
            //pass to the next process

        }
    }
}

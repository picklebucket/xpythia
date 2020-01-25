using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class GetAllCurrentResources : IBucketMagic
    {
        /// <summary>
        /// purpose is to get resource list to confirm that the dev exists and to get rate, billable rate and country code info
        /// </summary>
        /// <param name="args"></param>
        public void Process(BucketMagicArgs args)
        {
            //connect to mongoDB
            if (args.ResourcesService != null && args.Abort != true)
            {
                //get the table of current resources in the system
                args.ResourcesData = args.ResourcesService.GetActiveResourceTable();
            }
            else
                args.Abort = true;
            //pass to the next process

        }
    }
}

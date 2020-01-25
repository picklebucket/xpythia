using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Service.BucketMagic;
using RDotNet;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    //see TODO in pipeline factory
    public class TempInitializeResourcesService : IBucketMagic
    {
        public void Process(BucketMagicArgs args)
        {
            //instantiate mongoDB access
            if (args.ConnectionString != string.Empty)
            {
                args.ResourcesService = new ResourcesService();
                args.ResourcesService.Initialize(args.ConnectionString);
                if (args.SimpleResult == null)
                    args.SimpleResult = new Dictionary<string, string>();
            }
            else
                args.Abort = true;

            
            

        }
    }
}

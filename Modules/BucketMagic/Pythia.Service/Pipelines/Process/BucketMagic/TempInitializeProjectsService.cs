using BM.Service.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class TempInitializeProjectsService : IBucketMagic
    {
        public void Process(BucketMagicArgs args)
        {
            //instantiate mongoDB access
            if (args.ConnectionString != string.Empty)
            {
                args.ProjectsService = new ProjectsService();
                args.ProjectsService.Initialize(args.ConnectionString);
                if (args.SimpleResult == null)
                    args.SimpleResult = new Dictionary<string, string>();
            }
            else
                args.Abort = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public interface IBucketMagic
    {
        void Process(BucketMagicArgs args);
    }
}

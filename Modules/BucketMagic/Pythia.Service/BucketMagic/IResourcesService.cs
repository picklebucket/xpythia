using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IResourcesService
    {
        void Initialize(string connectionsString);
        List<ResourcesModel> GetActiveResourceTable();

    }
}

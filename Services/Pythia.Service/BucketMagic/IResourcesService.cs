using Pythia.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythia.Service.BucketMagic
{
    public interface IResourcesService
    {
        void Initialize(string connectionsString);
        List<ResourcesModel> GetActiveResourceTable();

    }
}

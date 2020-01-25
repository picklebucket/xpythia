using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IClientsService
    {
        void Initialize(string connectionsString);
        ClientsModel GetById(string id);
        ClientsModel GetByName(string name);
        ClientsModel Create(ClientsModel data);
        void UpdateById(string id, ClientsModel data);
        void Delete(string id);
    }
}

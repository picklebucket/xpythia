using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IProjectsService
    {
        void Initialize(string connectionsString);
        ProjectsModel GetById(string Id);
        List<ProjectsModel> GetByClientId(string clientId);
        ProjectsModel Create(ProjectsModel data);
        void UpdateById(string id, ProjectsModel data);
        void Delete(string Id);
        List<ProjectsModel> GetByStartDate(DateTime startDate);
    }
}

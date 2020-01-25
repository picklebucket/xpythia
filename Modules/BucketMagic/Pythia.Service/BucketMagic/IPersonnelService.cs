using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.BucketMagic
{
    public interface IPersonnelService
    {
        void Initialize(string connectionsString);
        PersonnelModel GetById(string id);
        PersonnelModel GetByName(string name);
        List<PersonnelModel> GetByIsActive(bool isActive);
        List<PersonnelModel> GetByStartDate(DateTime StartDate);
        PersonnelModel CreatePerson(PersonnelModel model);
        void UpdateById(string id, PersonnelModel model);
        void DeleteById(string id);
    }
}

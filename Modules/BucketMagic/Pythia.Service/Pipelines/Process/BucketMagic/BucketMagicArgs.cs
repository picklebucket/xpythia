using BM.Models.BucketMagic;
using BM.Service.BucketMagic;
using Pythia.Service.Pipelines;
using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class BucketMagicArgs : PipelineArgs
    {       
        //public REngine RSession { get; set; }
        public List<HoursModel> Data { get; set; }
        public List<ResourcesModel> ResourcesData { get; set; }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        
        public IHoursService HoursService { get; set; }
        public IResourcesService ResourcesService { get; set; }
        public IClientsService ClientsService { get; set; }
        public IPersonnelService PersonnelService { get; set; }
        public IExpensesService ExpensesService { get; set; }
        public IProjectsService ProjectsService { get; set; }
        public IPaymentsService PaymentsService { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string ActionName { get; set; }
        public Dictionary<string, string> SimpleResult { get; set; }
        public string ResourceName { get; set; }
        public int Hours { get; set; }
        public string Project { get; set; }
        public DateTime MondayWeekDate { get; set; }
    }
}

using BM.Service.BucketMagic;
using Pythia.Service.Pipelines;
using BM.Service.Pipelines.Process.BucketMagic;
using BM.UI.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BM.UI.Controllers
{
    public class BucketMagicController : ApiController
    {
        private IHoursService _hourService;
        private IResourcesService _resourceService;
        private const string _token = "39b59b082fd30af3b169d6af62f0c3e32094b357c0605df928f974c1424799f1";
        public BucketMagicController(IHoursService hs, IResourcesService rs)
        {
            _hourService = hs;
            _resourceService = rs;
        }
        // GET: BucketMagic
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            return null;
        }

        [System.Web.Http.HttpPost]
        public Dictionary<string, string> GetReport([FromBody] TempRequestModel data)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (data.Token != _token)
                return new Dictionary<string, string>();


            if (data.Action != string.Empty &&
                data.MinDate != null &&
                data.MaxDate != null)
            {
                try
                {
                    //run pipeline logic
                    //begin parseing
                    BucketMagicArgs args = new BucketMagicArgs();
                    //set values
                    args.MinDate = data.MinDate;
                    args.MaxDate = data.MaxDate;
                    args.ActionName = data.Action;
                    args.Abort = false;
                    args.HoursService = _hourService;

                    //TODO: make path configurable in config file
                    PipelineFactory pipeline = new PipelineFactory(data.Action, "bucketmagic_CI", new Object[] { args }, System.Web.Hosting.HostingEnvironment.MapPath("~/App_LocalResources/BucketMagic/ProcessBucketMagic.xml"));
                    args.ConnectionString = pipeline._connectionstring;
                    pipeline.Run();
                    if (args.SimpleResult.Any())
                    {
                        return args.SimpleResult;
                    }
                                
                }
                catch (Exception ex)
                {
                    result.Add("ERROR : ", ex.ToString());
                }
            }
            else
            {
                result.Add("ERROR : ", "One of the required properties was missing and the action was not performed");
            }
            return result;
        }

        [System.Web.Http.HttpPost]
        public Dictionary<string, string> SetData([FromBody] TempRequestModel data)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (data.Token != _token)
                return new Dictionary<string, string>();


            if (data.Action != string.Empty &&
                data.DateOfMonday != null &&
                data.NameOfProject != string.Empty &&
                data.NameOfResource != string.Empty)
            {
                try
                {
                    //run pipeline logic
                    //begin parseing
                    BucketMagicArgs args = new BucketMagicArgs();
                    //set values
                    args.ResourceName = data.NameOfResource;
                    args.Hours = data.Hours;
                    args.MondayWeekDate = data.DateOfMonday;
                    args.Project = data.NameOfProject;
                    args.ActionName = data.Action;
                    args.Abort = false;
                    args.ResourcesService = _resourceService;
                    args.CollectionName = "";

                    //TODO: make path configurable in config file
                    PipelineFactory pipeline = new PipelineFactory(data.Action, "bucketmagic_CI", new Object[] { args }, System.Web.Hosting.HostingEnvironment.MapPath("~/App_LocalResources/BucketMagic/ProcessBucketMagic.xml"));
                    args.ConnectionString = pipeline._connectionstring;
                    pipeline.Run();
                    if (args.SimpleResult.Any())
                    {
                        return args.SimpleResult;
                    }

                }
                catch (Exception ex)
                {
                    result.Add("ERROR : ", ex.ToString());
                }
            }
            else
            {
                result.Add("ERROR : ", "One of the required properties was missing and the action was not performed");
            }
            return result;
        }


    }
}
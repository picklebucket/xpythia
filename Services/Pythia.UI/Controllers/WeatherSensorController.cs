using Pythia.Models.WeatherSensor;
using Pythia.Service.Pipelines;
using Pythia.Service.Pipelines.Process.WeatherSensor;
using Pythia.Service.WeatherSensor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Pythia.UI.Controllers
{
    public class WeatherSensorController : ApiController
    {
        private IWeatherSensorService _weatherSensorService;

        public WeatherSensorController(IWeatherSensorService ws)
        {
            _weatherSensorService = ws;
        }
        // GET: WeatherSensor
        public HttpResponseMessage Index()
        {
            return null;
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Create(List<SensorReadingModel> value)
        {
            HttpResponseMessage result = null;

            if (value.Any())
            {

                try
                {
                    //begin parseing
                    WeatherSensorArgs args = new WeatherSensorArgs();
                    args.Data = value;
                    args.Abort = false;
                    //not needed
                    //args.ProcessedData = new WeatherSensorModel();
                    //TODO: make path configurable in config file
                    PipelineFactory pipeline = new PipelineFactory("ProcessReading", "weathersensor", new Object[] { args }, System.Web.Hosting.HostingEnvironment.MapPath("~/App_LocalResources/WeatherSensor/ProcessReading.xml"));
                    args.ConnectionString = pipeline._connectionstring;
                    pipeline.Run();
                    result = new HttpResponseMessage(HttpStatusCode.Created);
                }
                catch (Exception ex)
                {
                    result = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            return result;
        }
    }
}
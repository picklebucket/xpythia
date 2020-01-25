using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Pythia.Service;
using System.Web.Mvc;
using BM.Service.BucketMagic;
using WS.Service.WeatherSensor;

namespace Pythia.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            //TODO : need to make this configurable from config 
			var container = new UnityContainer();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IProductService, ProductService>();
            //container.RegisterType<IAddressServices, AddressService>();
            //container.RegisterType<ITypeService, TypeService>();
            //container.RegisterType<IPlansService, PlansService>();       
            container.RegisterType<IWeatherSensorService, WeatherSensorService>(new TransientLifetimeManager());
            container.RegisterType<IHoursService, HoursService>(new TransientLifetimeManager());
            container.RegisterType<IResourcesService, ResourcesService>(new TransientLifetimeManager());
            container.RegisterType<IClientsService, ClientsService>(new TransientLifetimeManager());
            container.RegisterType<IPersonnelService, PersonnelService>(new TransientLifetimeManager());
            container.RegisterType<IExpensesService, ExpensesService>(new TransientLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
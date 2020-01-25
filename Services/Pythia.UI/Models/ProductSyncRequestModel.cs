using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pythia.UI.Models
{
    public class ProductSyncRequestModel
    {
        public ProductSyncRequestModel()
        {

        }
        public string Key { get; set; }

        public List<ProductsSyncRequest> ProductsInSc { get; set; }
    }
    public class ProductsSyncRequest
    {
        public ProductsSyncRequest()
        { }
        
        public string Name { get; set; }
        public string ID { get; set; }
        public string TypeName { get; set; }
        public string PlanName { get; set; }
        public string ServiceName { get; set; }
    }
}
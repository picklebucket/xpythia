using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pythia.UI.Models
{
    public class ProductSyncResponseModel
    {
        public ProductSyncResponseModel()
        {

        }
        public string Key { get; set; }
        public List<ProductSyncResponse> Products { get; set; }
    }
    public class ProductSyncResponse
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string TypeName { get; set; }
        public string PlanName { get; set; }
        public string ServiceName { get; set; }
        public bool IsRemove { get; set; }
        public bool IsCreate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsUnchanged { get; set; }
    }
}
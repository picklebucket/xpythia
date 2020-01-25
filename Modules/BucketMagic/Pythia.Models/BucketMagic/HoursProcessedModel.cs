using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class HoursProcessedModel
    {
        public string Resource { get; set; }
        public string Location { get; set; }
        public decimal Hours { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public decimal PayRate { get; set; }
        public decimal CompleteCharge { get; set; }
        public decimal Profit { get; set; }
        public decimal TotalPayOut { get; set; }
        public decimal Gross { get; set; }
    }
}

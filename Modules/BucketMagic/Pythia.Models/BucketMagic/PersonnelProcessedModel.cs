using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class PersonnelProcessedModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Project { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Skills { get; set; }
        public decimal PayRate { get; set; }
        public string LinkToDocFolder { get; set; }
    }
}

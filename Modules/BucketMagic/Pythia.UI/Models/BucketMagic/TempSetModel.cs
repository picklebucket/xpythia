using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BM.UI.Models.BucketMagic
{
    /// <summary>
    /// remove
    /// </summary>
    public class TempSetModel
    {
        public string ActionType { get; set; }
        public string Action { get; set; }
        public DateTime MondayWeekDate { get; set; }
        public string Token { get; set; }
        public string ResourceName { get; set; }
        public int Hours { get; set; }
        public string Project { get; set; }
    }
}
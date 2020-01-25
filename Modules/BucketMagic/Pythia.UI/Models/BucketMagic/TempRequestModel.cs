using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BM.UI.Models.BucketMagic
{
    public class TempRequestModel
    {

        public string ActionType { get; set; }
        public string Action { get; set; }
        public string NameOfResource { get; set; }
        public string CountryCode { get; set; }
        public DateTime DateOfMonday { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string NameOfProject { get; set; }
        public int Hours { get; set; }
        public int Rate { get; set; }
        public int BillRate { get; set; }
        public string Token { get; set; }


    }
}
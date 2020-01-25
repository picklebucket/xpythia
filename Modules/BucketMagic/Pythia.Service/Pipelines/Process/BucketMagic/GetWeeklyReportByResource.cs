using BM.Models.BucketMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class GetWeeklyReportByResource : IBucketMagic
    {
        public void Process(BucketMagicArgs args)
        {
            //surmize all profit together without overhead
            args.SimpleResult = new Dictionary<string, string>();
            if (args.Data.Any())
            {
                List<HoursProcessedModel> retVal = new List<HoursProcessedModel>();
                foreach (var item in args.Data)
                {
                    retVal.Add(new HoursProcessedModel
                    {
                        Client = item.Client,
                        CompleteCharge = item.CompleteCharge,
                        Date = item.Date,
                        Hours = item.Hours,
                        Location = item.Location,
                        PayRate = item.PayRate,
                        Resource = item.Resource,
                        Profit = CalculateProfit(item.PayRate, item.Hours, item.CompleteCharge),
                        TotalPayOut = CalculateTotalCharge(item.Hours, item.PayRate),
                        Gross = CalculateGross(item.Hours, item.CompleteCharge)
                    });
                }
                var groupedResults = retVal.GroupBy(x => x.Resource).Select(cl => new
                {
                    Resource = cl.Key,
                    Hours = cl.Sum(cc => cc.Hours),
                    Profit = cl.Sum(cc => cc.Profit),
                    PayOut = cl.Sum(cc => cc.TotalPayOut)
                    
                });
                                      
                if (groupedResults.Any())
                {
                    foreach (var groupedResult in groupedResults)
                    {
                        args.SimpleResult.Add("Resource: " + groupedResult.Resource + " : ", String.Format(" Hours: {0}   Profit: {1}   Payout: {2}", groupedResult.Hours.ToString(), groupedResult.Profit.ToString(), groupedResult.PayOut.ToString()));
                    }
                }

                
            }
        }
        private decimal CalculateProfit(decimal payRate, decimal hours, decimal completeChargeRate)
        {
            decimal retVal = 0;

            var totalCharge = completeChargeRate * hours;
            retVal = totalCharge - (payRate * hours);

            return retVal;
        }
        private decimal CalculateTotalCharge(decimal hours, decimal payRate)
        {
            decimal retVal = 0;

            retVal = payRate * hours;

            return retVal;
        }
        private decimal CalculateGross(decimal hours, decimal completeCharges)
        {
            decimal retVal = 0;

            retVal = completeCharges * hours;

            return retVal;
        }
    }
}

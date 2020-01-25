using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Service.Pipelines.Process.BucketMagic
{
    public class SetHourRecordByValidResource : IBucketMagic
    {
        public void Process(BucketMagicArgs args)
        {
            //connect to mongoDB
            if (args.ResourcesService != null && args.Abort != true)
            {
                //check that provided resource actually exists
                if (args.ResourcesData.Where(x => x.Name == args.ResourceName).Any())
                {
                    //resource is valid
                    var resource = args.ResourcesData.Where(x => x.Name == args.ResourceName).First();

                    //iterate through 7 days using the start data assuming that it is monday (current requirement, will change)
                    DateTime context = args.MondayWeekDate;
                    //DateTime endDate = startDate.AddDays(7);
                    //take the data and fill hours model
                    //TODO: better error handling and recording 
                    //TODO: eventually this will be re written once the front end ui is done
                    //assuming even spread of hours over 5 work days, average out and add to list
                    List<int> avgHours = new List<int>();
                    //get average
                    int sum = args.Hours;
                    int avgHour = sum / 5;

                    //if weekday add in avg hour, if weekend enter 0
                    for (int a = 0; a < 7; a++)
                    {
                        if (a < 5)
                            avgHours.Add(avgHour);
                        else
                            avgHours.Add(0);
                    }
                    avgHours.ToList();
                    // for (DateTime context = startDate; context < endDate; context.AddDays(1))
                    for (int a = 0; a < 7; a++)
                    {   
                        args.HoursService.SetByResource(new Models.BucketMagic.HoursModel
                        {
                            Client = args.Project,
                            CompleteCharge = resource.ExternalRate,
                            Date = context,
                            Hours = avgHours[a],
                            Location = resource.Country,
                            PayRate = resource.InternalRate,
                            Resource = resource.Name
                        });
                        context = context.AddDays(1);
                    }

                }
                else
                {
                    //there was no matching resource in the records
                    args.SimpleResult.Add("ERROR: ", "When trying to set the record, there no matching resource found in the resources collection. Make sure that the resource is present, spelled correctly and 'active'");
                }
            }
            else
                args.Abort = true;
            //pass to the next process

        }
    }
}

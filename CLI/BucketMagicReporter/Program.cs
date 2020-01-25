using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BM
{
    /// <summary>
    /// intended as temp solution until front end UI is built and connected
    /// </summary>
    class Program
    {
        private const string apiBase = "PythiaApi/BucketMagic/";
        //used only temp for security. final product will use authentication through a web app
        private const string tempToken = "39b59b082fd30af3b169d6af62f0c3e32094b357c0605df928f974c1424799f1";
        //private const string apiUrl = "http://pythia.chapinindustries.com";
        private const string apiUrl = "http://local.pythia/";
        /// <summary>
        /// main program
        /// </summary>
        /// <param name="args">Action DateMin DateMax</param>
        static void Main(string[] args)
        {
            //need to handle commands and interations with the web service to get reports
            //testing set 
            //args = new string[9] { "SET", "SETWEEK", "Artem", "BY", "8/19/2019", "CMG", "40", "34", "45" };

            //testing get
            //args = new string[4] { "GET", "GETWEEKLYPROFITGROSS", "1/1/2019", "1/31/2019" };

            //testing only old
            //args = new string[3] { "GETWEEKLYPROFITGROSS", "1/1/2019", "1/31/2019" };
            //check to make sure that the args are populated, if not return error
            if (args.Any())
            {
                //also check to make sure that the date fields represent real date values

                Dictionary<string, string> results = new Dictionary<string, string>();
                if (args[0] == "SET")
                {
                    List<DateTime> date = GetRealDates(args, 4, 0);
                    if (date.Any())
                    {
                        //TODO: update so it is pulled from resource table based on project
                        RequestModel req = new RequestModel
                        {
                            Action = args[1].ToUpper(),
                            DateOfMonday = date.FirstOrDefault(),
                            NameOfResource = args[2],
                            CountryCode = args[3].ToUpper(),
                            NameOfProject = args[5],
                            Hours = ConvertToNumber(args[6]),
                            Rate = ConvertToNumber(args[7]),
                            BillRate = ConvertToNumber(args[8]),

                            Token = tempToken
                        };

                        switch (req.Action)
                        {
                            case "SETWEEK":
                                req.ActionType = "SetData";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            default:
                                Console.WriteLine("Check your command list by using PROGRAM.exe man to make sure that the actions were typed correctly");
                                break;
                        }
                        if (results.Any())
                        {
                            foreach (var result in results)
                            {
                                Console.WriteLine(result.Key + " : " + result.Value);
                            }
                            Console.ReadKey();
                        }

                    }
                    else if (args[0].ToUpperInvariant() == "MAN")
                    {
                        PrintMan();
                    }
                }
                else if (args[0] == "GET")
                {
                    List<DateTime> minMaxDates = GetRealDates(args, 2, 3);
                    if (minMaxDates.Count == 2)
                    {
                        RequestModel req = new RequestModel
                        {
                            Action = args[1].ToUpper(),
                            MinDate = minMaxDates[0],
                            MaxDate = minMaxDates[1],
                            Token = tempToken
                        };

                        //switch to find the correct action
                        switch (req.Action)
                        {
                            case "GETWEEKLYPROFITGROSS":
                                //connect to web service 
                                req.ActionType = "GetReport";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            case "GETWEEKLYPROFITNET":
                                //do stuff
                                req.ActionType = "GetReport";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            case "GETWEEKLYREPORTBYCLIENT":
                                //do more stuff
                                req.ActionType = "GetReport";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            case "GETWEEKLYREPORTBYRESOURCE":
                                //do stuff
                                req.ActionType = "GetReport";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            case "SETWEEKLYRESOURCERECORD":
                                //do shit
                                req.ActionType = "SetData";
                                results = ConnectToService(req).GetAwaiter().GetResult();
                                break;
                            default:
                                Console.WriteLine("Check your command list by using PROGRAM.exe man to make sure that the actions were typed correctly");
                                break;
                        }
                        //write to screen
                        if (results.Any())
                        {
                            foreach (var result in results)
                            {
                                Console.WriteLine(result.Key + " : " + result.Value);
                            }
                            Console.ReadKey();
                        }


                    }
                   
                    else
                    {
                        Console.WriteLine("You must provide proper dates in the form of mm/dd/yyyy");
                        Console.ReadKey();
                    }
                }
                else if (args[0].ToUpperInvariant() == "MAN")
                {
                    PrintMan();
                }
                else
                {
                    //there was an issue as the requried get or set was not present in index 0
                    Console.WriteLine("You must provide proper dates in the form of mm/dd/yyyy");
                    Console.ReadKey();
                }




            }
            else
            {
                Console.WriteLine("You must provide variables, i.e., Command.exe ACTION DATEMIN DATEMAX with the dates being in m/d/yyyy format ");
                Console.ReadKey();
            }


        }
        private static async Task<Dictionary<string, string>> ConnectToService(RequestModel data)
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            //this will connect to the service and then get the data from it
            //need to rewrite
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            //execute the proper command

            //wait for response
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //push results
            HttpResponseMessage responce = await client.PostAsJsonAsync(apiUrl + apiBase + data.ActionType, data);
            if (responce.IsSuccessStatusCode)
            {
                var resultString = await responce.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(resultString);

            }
            else
            {
                retVal.Add("ERROR: ", "There was an issue communicating with the service");
            }
            return retVal;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex">using 0 will skip</param>
        /// <returns></returns>
        private static List<DateTime> GetRealDates(string[] args, int firstIndex, int secondIndex)
        {
            List<DateTime> retVal = new List<DateTime>();

            try
            {
                retVal.Add(Convert.ToDateTime(args[firstIndex]));
                if (secondIndex > 0)
                {
                    retVal.Add(Convert.ToDateTime(args[secondIndex]));
                }


            }
            catch (Exception ex)
            {

                return retVal;
            }

            return retVal;
        }
        private static int ConvertToNumber(string numberToConvert)
        {
            try
            {
                return Convert.ToInt16(numberToConvert);
            }
            catch
            {
                return 0;
            }
        }
        private static void PrintMan()
        {
            Console.WriteLine("The available commands/actions are:");
            Console.WriteLine("GETWEEKLYPROFITGROSS");
            Console.WriteLine("GETWEEKLYPROFITNET");
            Console.WriteLine("GETWEEKLYREPORTBYCLIENT");
            Console.WriteLine("GETWEEKLYREPORTBYRESOURCE");
            Console.WriteLine("SETWEEK");
            Console.WriteLine("You must also add in min and max dates, i.e.,  Command.exe ACTION DATEMIN DATEMAX with the dates being in m/d/yyyy format ");
            Console.WriteLine("To set, use the following command : SET ACTION ResourceName CountryCode DateStartingMonday Project HoursTotal rate biilRate");
            Console.ReadKey();
        }

    }
    class RequestModel
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

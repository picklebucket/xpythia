using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketMagicImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string csv = "";
            string resources = "";
            string payments = "";
            string personnel = "";
            string hours = "";
            string expenses = "";
            string projects = "";
            string clients = "";


            List<CIRecords> records = new List<CIRecords>();
            List<CIResourcesPayments> recordsPayments = new List<CIResourcesPayments>();
            List<CIResourcesPersonnel> recordsPersonnel = new List<CIResourcesPersonnel>();
            List<CIResourcesExpenses> recordsExpenses = new List<CIResourcesExpenses>();
            List<CIResourcesProjects> recordsProjects = new List<CIResourcesProjects>();
            List<CIResourcesClients> recordsClients = new List<CIResourcesClients>();
            List<CIResourcesHours> recordsHours = new List<CIResourcesHours>();


            List<CIResources> lstResources = new List<CIResources>();
            IMongoCollection<CIRecords> _ciRecords;
            IMongoCollection<CIResources> _ciResources;
            IMongoCollection<CIResourcesService> _ciResourcesService;
            IMongoCollection<CIResourcesPersonnel> _ciResourcesPersonnel;
            IMongoCollection<CIResourcesExpenses> _ciResourcesExpenses;
            IMongoCollection<CIResourcesProjects> _ciResourcesProjects;
            IMongoCollection<CIResourcesPayments> _ciResourcesPayments;
            IMongoCollection<CIResourcesClients> _ciResourcesClients;
            IMongoCollection<CIResourcesHours> _ciResourcesHours;
            



            List<CIRecords> resourceList = new List<CIRecords>();
            //testing with local host atm 23.96.93.91
            string connectionsString = "mongodb://localhost/BucketMagic_CI";
            //string connectionsString = "mongodb://23.96.93.91/BucketMagic_CI";
            //import file csv
            StreamReader sr = new StreamReader(@"c:\temp\CI_Records.csv");
            csv = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();

            StreamReader srResources = new StreamReader(@"c:\temp\CI_Resources.csv");
            resources = srResources.ReadToEnd();
            srResources.Close();
            srResources.Dispose();

            StreamReader srPayments = new StreamReader(@"c:\temp\BM_Payments.csv");
            payments = srPayments.ReadToEnd();
            srPayments.Close();
            srPayments.Dispose();

            StreamReader srPersonnel = new StreamReader(@"c:\temp\BM_Personnel.csv");
            personnel = srPersonnel.ReadToEnd();
            srPersonnel.Close();
            srPersonnel.Dispose();

            StreamReader srHours = new StreamReader(@"c:\temp\BM_Hours.csv");
            hours = srHours.ReadToEnd();
            srHours.Close();
            srHours.Dispose();

            StreamReader srExpenses = new StreamReader(@"c:\temp\BM_Expenses.csv");
            expenses = srExpenses.ReadToEnd();
            srExpenses.Close();
            srExpenses.Dispose();


            StreamReader srProjects = new StreamReader(@"c:\temp\BM_Projects.csv");
            projects = srProjects.ReadToEnd();
            srProjects.Close();
            srProjects.Dispose();

            StreamReader srClients = new StreamReader(@"c:\temp\BM_Clients.csv");
            clients = srClients.ReadToEnd();
            srClients.Close();
            srClients.Dispose();


            //load into model
            if (csv != string.Empty)
            {
                csv = csv.Replace("\n", "");
                string[] rows = csv.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "resource")
                                continue;

                            records.Add(new CIRecords
                            {
                                Resource = sRow[0],
                                Location = sRow[1],
                                Hours = ConvertDecimal(sRow[2]),
                                Date = ConvertDate(sRow[3]),
                                Client = sRow[4],
                                PayRate = ConvertDecimal(sRow[5]),
                                CompleteCharge = ConvertDecimal(sRow[6])
                            });

                        }
                    }

                    //wipe DB collection

                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciRecords = database.GetCollection<CIRecords>("Hours_CI");
                    //wipe records
                    _ciRecords.DeleteMany(Builders<CIRecords>.Filter.Empty);
                    //insert records
                    _ciRecords.InsertMany(records);
                    //iterate through and post to mongoDB
                }
            }

            //import the resource list
            if (resources != string.Empty)
            {
                resources = resources.Replace("\n", "");
                string[] rows = resources.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "resources")
                                continue;

                            lstResources.Add(new CIResources
                            {
                                ProjectName = sRow[0],
                                Name = sRow[1],
                                EmailAddress = sRow[2],
                                StartDate = ConvertDate(sRow[3]),
                                EndDate = ConvertDate(sRow[4]),
                                IsCurrent = ConvertBool(sRow[5]),
                                Country = sRow[6],
                                InternalRate = ConvertDecimal(sRow[7]),
                                ExternalRate = ConvertDecimal(sRow[8]),
                                IsSitecoreDev = ConvertBool(sRow[9]),
                                IsEpiDev = ConvertBool(sRow[10]),
                                IsNetDev = ConvertBool(sRow[11]),
                                IsUmbracoDev = ConvertBool(sRow[12]),
                                isFrontEndDev = ConvertBool(sRow[13]),
                                Notes = sRow[14]
                            });

                        }
                    }

                    //wipe DB collection

                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResources = database.GetCollection<CIResources>("Resources_CI");
                    //wipe records
                    _ciResources.DeleteMany(Builders<CIResources>.Filter.Empty);
                    //insert records
                    _ciResources.InsertMany(lstResources);
                    //iterate through and post to mongoDB
                }
            }

            //load into model
            if (payments != string.Empty)
            {
                payments = payments.Replace("\n", "");
                string[] rows = payments.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "resource")
                                continue;

                            recordsPayments.Add(new CIResourcesPayments
                            {
                                Client = sRow[0],
                                Amount = ConvertDecimal(sRow[2]),
                                DatePaid = ConvertDate(sRow[6]),
                                DateSent = ConvertDate(sRow[5]),
                                LinkToInvoice = sRow[6],
                                Project = sRow[1],
                                Status = ConvertBool(sRow[4]),
                                Term = ConvertInt(sRow[3]),
                            });

                        }
                    }

                    //wipe DB collection

                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesPayments = database.GetCollection<CIResourcesPayments>("Resources_CI");
                    //wipe records
                    _ciResourcesPayments.DeleteMany(Builders<CIResourcesPayments>.Filter.Empty);
                    //insert records
                    _ciResourcesPayments.InsertMany(recordsPayments);
                    //iterate through and post to mongoDB
                }
            }

            if (personnel != string.Empty)
            {
                personnel = personnel.Replace("\n", "");
                string[] rows = personnel.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "personnel")
                                continue;

                            recordsPersonnel.Add(new CIResourcesPersonnel
                            {
                                Email = sRow[2],
                                Name = sRow[0],
                                Project = sRow[1],
                                StartDate = ConvertDate(sRow[4]),
                                EndDate = ConvertDate(sRow[5]),
                                IsActive = ConvertBool(sRow[3]),
                                PayRate = ConvertDecimal(sRow[7]),
                                LinkToDocFolder = sRow[8],
                                Skills = sRow[6],
                            });

                        }
                    }

                    //wipe DB collection

                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesPersonnel = database.GetCollection<CIResourcesPersonnel>("Personnel_CI");
                    //wipe records
                    _ciResourcesPersonnel.DeleteMany(Builders<CIResourcesPersonnel>.Filter.Empty);
                    //insert records
                    _ciResourcesPersonnel.InsertMany(recordsPersonnel);
                    //iterate through and post to mongoDB
                }
            }

            if (expenses != string.Empty)
            {
                expenses = expenses.Replace("\n", "");
                string[] rows = expenses.Split('\r');

                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "expense")
                                continue;

                            recordsExpenses.Add(new CIResourcesExpenses
                            {
                                Amount = ConvertDecimal(sRow[3]),
                                Date = ConvertDate(sRow[2]),
                                Description = sRow[1],
                                //TaxCategory = , //todo
                                Title = sRow[0],
                            });

                        }
                    }

                    //wipe DB collection
                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesExpenses = database.GetCollection<CIResourcesExpenses>("Expenses_CI");
                    //wipe records
                    _ciResourcesExpenses.DeleteMany(Builders<CIResourcesExpenses>.Filter.Empty);
                    //insert records
                    _ciResourcesExpenses.InsertMany(recordsExpenses);
                    //iterate through and post to mongoDB
                }
            }

            if (projects != string.Empty)
            {
                projects = projects.Replace("\n", "");
                string[] rows = projects.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "project")
                                continue;

                            recordsProjects.Add(new CIResourcesProjects
                            {
                                ClientName = sRow[0],
                                Description = sRow[1],
                                StartDate = ConvertDate(sRow[2]),
                                EndDate = ConvertDate(sRow[3]),
                            });

                        }
                    }

                    //wipe DB collection
                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesProjects = database.GetCollection<CIResourcesProjects>("Projects_CI");
                    //wipe records
                    _ciResourcesProjects.DeleteMany(Builders<CIResourcesProjects>.Filter.Empty);
                    //insert records
                    _ciResourcesProjects.InsertMany(recordsProjects);
                    //iterate through and post to mongoDB
                }
            }

            if (clients != string.Empty)
            {
                clients = clients.Replace("\n", "");
                string[] rows = clients.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "client")
                                continue;

                            recordsClients.Add(new CIResourcesClients
                            {
                                Name = sRow[0],
                                Description = sRow[1],
                                StartDate = ConvertDate(sRow[2]),
                                EndDate = ConvertDate(sRow[3]),
                                PoCEmail = sRow[4]
                            });

                        }
                    }

                    //wipe DB collection
                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesClients = database.GetCollection<CIResourcesClients>("Clients_CI");
                    //wipe records
                    _ciResourcesClients.DeleteMany(Builders<CIResourcesClients>.Filter.Empty);
                    //insert records
                    _ciResourcesClients.InsertMany(recordsClients);
                    //iterate through and post to mongoDB
                }
            }


            if (hours != string.Empty)
            {
                hours = hours.Replace("\n", "");
                string[] rows = hours.Split('\r');
                if (rows.Any())
                {
                    foreach (var row in rows)
                    {
                        Console.WriteLine("Adding new record: " + row);
                        string[] sRow = row.Split(',');
                        if (sRow.Any())
                        {
                            //catch first row
                            if (sRow[0].ToLower() == "hour")
                                continue;

                            recordsHours.Add(new CIResourcesHours
                            {
                                Client = sRow[4],              
                                CompleteCharge = sRow[6],
                                Date = ConvertDate(sRow[3]),
                                Hours = ConvertInt(sRow[2]),
                                Location = sRow[1],
                                PayRate = ConvertInt(sRow[6]), 
                                Resource = sRow[0]
                            });
                        }
                    }

                    //wipe DB collection
                    var client = new MongoClient(connectionsString);
                    var database = client.GetDatabase("BucketMagic_CI");
                    _ciResourcesHours = database.GetCollection<CIResourcesHours>("Hours_CI");
                    //wipe records
                    _ciResourcesHours.DeleteMany(Builders<CIResourcesHours>.Filter.Empty);
                    //insert records
                    _ciResourcesHours.InsertMany(recordsHours);
                    //iterate through and post to mongoDB
                }
            }
        }

        private static DateTime ConvertDate(string value)
        {
            DateTime retVal = new DateTime();
            if (value != string.Empty)
            {
                return Convert.ToDateTime(value);
            }
            return retVal;
        }
        private static decimal ConvertDecimal(string value)
        {
            decimal retVal = 0;
            if (value != string.Empty)
            {
                decimal.TryParse(value, out retVal);
            }
            return retVal;
        }
        private static bool ConvertBool(string value)
        {
            bool retVal = false;
            if (value != null)
            {
                bool.TryParse(value.ToLower(), out retVal);
            }
            return retVal;
        }

        private static int ConvertInt(string value)
        {
            int retVal = 0;
            if (value != null)
            {
                int.TryParse(value.ToLower(), out retVal);
            }
            return retVal;
        }




        public class CIRecords
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Resource")]
            public string Resource { get; set; }
            [BsonElement("Location")]
            public string Location { get; set; }
            [BsonElement("Hours")]
            public decimal Hours { get; set; }
            [BsonElement("Date")]
            public DateTime Date { get; set; }
            [BsonElement("Client")]
            public string Client { get; set; }
            [BsonElement("PayRate")]
            public decimal PayRate { get; set; }
            [BsonElement("CompleteCharge")]
            public decimal CompleteCharge { get; set; }
        }
        public class CIResources
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("ProjectName")]
            public string ProjectName { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("EmailAddress")]
            public string EmailAddress { get; set; }
            [BsonElement("StartDate")]
            public DateTime StartDate { get; set; }
            [BsonElement("EndDate")]
            public DateTime EndDate { get; set; }
            [BsonElement("IsCurrent")]
            public bool IsCurrent { get; set; }
            [BsonElement("Country")]
            public string Country { get; set; }
            [BsonElement("InternalRate")]
            public decimal InternalRate { get; set; }
            [BsonElement("ExternalRate")]
            public decimal ExternalRate { get; set; }
            [BsonElement("IsSitecoreDev")]
            public bool IsSitecoreDev { get; set; }
            [BsonElement("IsEpiDev")]
            public bool IsEpiDev { get; set; }
            [BsonElement("IsNetDev")]
            public bool IsNetDev { get; set; }
            [BsonElement("IsUmbracoDev")]
            public bool IsUmbracoDev { get; set; }
            [BsonElement("IsFrontEndDev")]
            public bool isFrontEndDev { get; set; }
            [BsonElement("Notes")]
            public string Notes { get; set; }
        }


        public class CIResourcesService
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("StartDate")]
            public DateTime StartDate { get; set; }
            [BsonElement("EndDate")]
            public DateTime EndDate { get; set; }
            [BsonElement("EmailAddress")]
            public string EmailAddress { get; set; }
        }


        public class CIResourcesClients
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Description")]
            public string Description { get; set; }
            [BsonElement("StartDate")]
            public DateTime StartDate { get; set; }
            [BsonElement("EndDate")]
            public DateTime EndDate { get; set; }
            [BsonElement("PoCEmail")]
            public string PoCEmail { get; set; }
        }


        public class CIResourcesPersonnel
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Name")]
            public string Name { get; set; }
            [BsonElement("Project")]
            public string Project { get; set; }
            [BsonElement("Email")]
            public string Email { get; set; }
            [BsonElement("IsActive")]
            public bool IsActive { get; set; }
            [BsonElement("StartDate")]
            public DateTime StartDate { get; set; }
            [BsonElement("EndDate")]
            public DateTime EndDate { get; set; }
            [BsonElement("Skills")]
            public string Skills { get; set; }
            [BsonElement("PayRate")]
            public decimal PayRate { get; set; }
            [BsonElement("LinkToDocFolder")]
            public string LinkToDocFolder { get; set; }
        }

        public class CIResourcesExpenses
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Title")]
            public string Title { get; set; }
            [BsonElement("Description")]
            public string Description { get; set; }
            [BsonElement("Date")]
            public DateTime Date { get; set; }
            [BsonElement("Amount")]
            public decimal Amount { get; set; }
            [BsonElement("TaxCategory")]
            public TaxCategory TaxCategory { get; set; }
        }

        public class CIResourcesProjects
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("ClientName")]
            public string ClientName { get; set; }
            [BsonElement("Description")]
            public string Description { get; set; }
            [BsonElement("StartDate")]
            public DateTime StartDate { get; set; }
            [BsonElement("EndDate")]
            public DateTime EndDate { get; set; }
        }

        public class CIResourcesPayments
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Client")]
            public string Client { get; set; }
            [BsonElement("Project")]
            public string Project { get; set; }
            [BsonElement("Amount")]
            public decimal Amount { get; set; }
            [BsonElement("Term")]
            public int Term { get; set; }
            [BsonElement("Status")]
            public bool Status { get; set; }
            [BsonElement("DateSent")]
            public DateTime DateSent { get; set; }
            [BsonElement("DatePaid")]
            public DateTime DatePaid { get; set; }
            [BsonElement("LinkToInvoice")]
            public string LinkToInvoice { get; set; }
        }


        public class CIResourcesHours
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            [BsonElement("Resource")]
            public string Resource { get; set; }
            [BsonElement("Location")]
            public string Location { get; set; }
            [BsonElement("Hours")]
            public int Hours { get; set; }
            [BsonElement("Date")]
            public DateTime Date { get; set; }
            [BsonElement("Client")]
            public string Client { get; set; }
            [BsonElement("PayRate")]
            public decimal PayRate { get; set; }
            [BsonElement("CompleteCharge")]
            public string CompleteCharge { get; set; }
        }
    }

    public enum TaxCategory
    {
        Interest,
        Equipment,
        OfficeSupplies,
        Travel,
        InvoicePayment,
        InvoiceReceipt,
        Subscriptions,
        Other
    }
}

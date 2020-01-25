using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pythia.Models.BucketMagic
{
    public class HoursModel
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
}

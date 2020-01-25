using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class PaymentsModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Client")]
        public ClientsModel Client { get; set; }
        [BsonElement("Project")]
        public ProjectsModel Project { get; set; }
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
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class ClientsProcessedModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("StartDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("EndtDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("PoCEmail")]
        public DateTime PoCEmail { get; set; }
    }
}

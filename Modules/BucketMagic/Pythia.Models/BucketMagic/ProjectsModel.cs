using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class ProjectsModel
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

        public ICollection<ClientsModel> Clients { get; set; }
        public ICollection<PaymentsModel> Payments { get; set; }
    }
}

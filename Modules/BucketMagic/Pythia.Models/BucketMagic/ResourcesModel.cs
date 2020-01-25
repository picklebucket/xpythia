using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class ResourcesModel
    {
        
        [BsonElement("ProjectName")]
        public string ProjectName { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
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
}

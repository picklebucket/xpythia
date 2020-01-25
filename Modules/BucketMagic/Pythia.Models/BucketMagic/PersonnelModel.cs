using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class PersonnelModel
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
}

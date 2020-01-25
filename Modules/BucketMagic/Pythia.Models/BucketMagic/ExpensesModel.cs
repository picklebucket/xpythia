using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Models.BucketMagic
{
    public class ExpensesModel
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

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace gs2Gb93266Ez92955.Models
{
    public class ConsumptionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("consumption")]
        public double Consumption { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}

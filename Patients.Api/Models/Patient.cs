using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Patients.Api.Models
{
    public class Patient
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Ailment> Ailments { get; set; }

        public ICollection<Medication> Medications { get; set; }
    }
}
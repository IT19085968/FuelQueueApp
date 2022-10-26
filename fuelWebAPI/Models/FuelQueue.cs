using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fuelWebAPI.Models{
    [BsonIgnoreExtraElements]
    public class FuelQueue{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;} = String.Empty;

        [BsonElement("stId")]
        public string FuelStationId{get;set;} = String.Empty;

        [BsonElement("joinedOn")]
        public DateTime JoinedOn{get;set;}

        [BsonElement("exitedOn")]
        public DateTime ExitedOn{get;set;}

        [BsonElement("vehicle")]
        public string VehicleType{get;set;} = String.Empty;

        [BsonElement("fuelStatus")]
        public bool FuelStatus{get;set;}

    }
}
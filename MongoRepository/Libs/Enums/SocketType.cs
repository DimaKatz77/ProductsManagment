using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DataAccessLayer.Libs.Enums
{
    public enum SocketType
    {
        [BsonRepresentation(BsonType.String)]
        [EnumMember(Value = "UK")]
        UK,
        [BsonRepresentation(BsonType.String)]
        [EnumMember(Value = "EU")]
        EU,
        [BsonRepresentation(BsonType.String)]
        [EnumMember(Value = "US")]
        US
    }
}

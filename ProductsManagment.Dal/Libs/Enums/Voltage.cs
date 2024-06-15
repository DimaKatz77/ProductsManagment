using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ProductsManagment.DAL.Libs.Enums
{
    public enum Voltage
    {
        [BsonRepresentation(BsonType.String)]
        [EnumMember(Value = "110V")]
        _110V,
        [BsonRepresentation(BsonType.String)]
        [EnumMember(Value = "220V")]
        _220V
    }
}

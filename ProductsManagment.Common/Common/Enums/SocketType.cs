using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProductsManagment.Common.Common.Enums
{
    public enum SocketType
    {
        [EnumMember(Value = "UK")]
        UK,
        [EnumMember(Value = "EU")]
        EU,
        [EnumMember(Value = "US")]
        US
    }
}

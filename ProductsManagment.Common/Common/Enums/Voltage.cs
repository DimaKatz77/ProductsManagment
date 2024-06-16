using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ProductsManagment.Common.Common.Enums
{
    public enum Voltage
    {
        [EnumMember(Value = "110V")]
        _110V,
        [EnumMember(Value = "220V")]
        _220V
    }
}

using DataAccessLayer.Libs.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Libs
{
    public class ElectricProduct : Category
    {
        [BsonElement("socketType")]
        public SocketType SocketType { get; set; }

        [BsonElement("voltage")]
        public Voltage Voltage { get; set; }
    }
}

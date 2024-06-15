using MongoDB.Bson.Serialization.Attributes;
using ProductsManagment.DAL.Libs.Enums;

namespace ProductsManagment.DAL.Libs
{
    public class ElectricProduct : Category
    {
        [BsonElement("socketType")]
        public SocketType SocketType { get; set; }

        [BsonElement("voltage")]
        public Voltage Voltage { get; set; }
    }
}

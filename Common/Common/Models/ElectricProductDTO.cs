using ProductsManagment.Common.Common.Enums;
using System.Text.Json.Serialization;

namespace ProductsManagment.Common.Common.Models
{
    public class ElectricProductDTO : CategoryDto
    {
        [JsonPropertyName("socketType")]
        public SocketType SocketType { get; set; }

        [JsonPropertyName("voltage")]
        public Voltage Voltage { get; set; }
    }
}

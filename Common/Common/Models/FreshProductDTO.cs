using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductsManagment.Common.Common.Models
{
    public class FreshProductDTO : CategoryDto
    {
        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }
    }
}

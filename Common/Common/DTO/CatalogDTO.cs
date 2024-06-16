using MongoDB.Bson.Serialization.Attributes;
using ProductsManagment.DAL.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.Common.Common.DTO
{
    public class CatalogDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }
    }
}

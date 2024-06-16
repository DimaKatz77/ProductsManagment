using MongoDB.Bson.Serialization.Attributes;
using ProductsManagment.DAL.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.Common.Common.DTO
{
    public class ProductDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public CategoryDto Category { get; set; }
    }
}

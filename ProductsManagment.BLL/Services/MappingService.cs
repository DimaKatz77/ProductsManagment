using ProductsManagment.Common.Common.Models;
using ProductsManagment.DAL.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagment.BLL.Services
{
    //Static Mapping Class
    public static class MappingService
    {
        public static Product ProductDtoToProduct(ProductDto dto)
        {
            if (dto is null)
                return null;
            var product = new Product();
            if (dto.Id != null)
                product.Id = new MongoDB.Bson.ObjectId(dto.Id);
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.IsActive = dto.IsActive;
            product.Title = dto.Title;
            if (dto.Category is ElectricProductDTO e)
            {
                product.Category = new ElectricProduct { SocketType = e.SocketType, Voltage = e.Voltage };
            }
            else if (dto.Category is FreshProductDTO f)
            {
                product.Category = new FreshProduct { ExpiryDate = f.ExpiryDate };
            }
            product.Price = dto.Price;
            return product;
        }

        public static ProductDto ProductToProductDTO(Product product)
        {
            if (product is null)
                return null;
            var dto = new ProductDto();
            dto.Id = product.Id.ToString();
            dto.Description = product.Description;
            dto.Price = product.Price;
            dto.IsActive = product.IsActive;
            dto.Title = product.Title;
            if (product.Category is ElectricProduct e)
            {
                dto.Category = new ElectricProductDTO { SocketType = e.SocketType, Voltage = e.Voltage };
            }
            else if (product.Category is FreshProduct f)
            {
                dto.Category = new FreshProductDTO { ExpiryDate = f.ExpiryDate };
            }
            dto.Price = product.Price;
            return dto;
        }

        public static Catalog CatalogDtoToCatalog(CatalogDto dto)
        {
            if (dto is null) return null;
            var catalog = new Catalog();
            if (dto.Id != null)
                catalog.Id = new MongoDB.Bson.ObjectId(dto.Id);
            catalog.Title = dto.Title;
            if (dto.Products != null)
                catalog.Products = dto.Products.Select(x => ProductDtoToProduct(x));

            return catalog;

        }

        public static CatalogDto CatalogToCatalogDto(Catalog catalog)
        {
            if (catalog is null) return null;

            var dto = new CatalogDto();
            dto.Id = catalog.Id.ToString();
            dto.Title = catalog.Title;
            if (catalog.Products != null)
                dto.Products = catalog.Products.Select(x => ProductToProductDTO(x));
            return dto;

        }
    }
}

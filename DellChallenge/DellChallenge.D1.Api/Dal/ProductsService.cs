using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);

            _context.Products.Add(product);
            _context.SaveChanges();

            var addedDto = MapToDto(product);
            return addedDto;
        }
            
        public ProductDto Delete(string id)
        {
            var prodToDelete = _context.Products.Where(item => item.Id == id.ToString()).FirstOrDefault();

            if (prodToDelete == null)
            {
                return null;
            }

            _context.Products.Remove(prodToDelete);
            _context.SaveChanges();

            return MapToDto(prodToDelete);
        }

        public ProductDto Update(string id, ProductDto productDto)
        {
            var product = _context.Products.Where(item => item.Id == id).FirstOrDefault();
            if (product == null)
            {
                return null;
            }
                       
            product.Name = productDto.Name;
            product.Category = productDto.Category;

            _context.Products.Update(product);
            _context.SaveChanges();

            var updatedDto = MapToDto(product);

            return updatedDto;
        }


        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}

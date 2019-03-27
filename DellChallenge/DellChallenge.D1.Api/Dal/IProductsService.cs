using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Add(NewProductDto newProduct);
        ProductDto Update(string id, ProductDto productDto);
        ProductDto Delete(string id);
    }
}

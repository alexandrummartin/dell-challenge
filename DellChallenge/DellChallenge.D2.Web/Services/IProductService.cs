using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Add(NewProductModel newProduct);

        void Update(string id, ProductModel product);

        ProductModel Get(string Id);

        void Delete(string id);
    }
}
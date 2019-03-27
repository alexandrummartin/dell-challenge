using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Get(string id)
        {

            var product = _productsService.GetAll().Where(item => item.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Delete(string id)
        {
            var product = _productsService.Delete(id);

            if (product == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Put(string id, [FromBody] ProductDto product)
        {
            var udatedProd = _productsService.Update(id, product);

            if (udatedProd == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

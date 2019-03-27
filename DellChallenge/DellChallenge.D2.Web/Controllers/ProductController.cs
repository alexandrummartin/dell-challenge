using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", newProduct);
            }

            _productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var productModel = _productService.Get(id);

            return View("Edit", productModel);
        }

        [HttpPost]
        public IActionResult Update(ProductModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            _productService.Update(model.Id, model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);

            return Json(new { ok = true, redirectUrl = Url.Action("Index", "Product") });
        }
    }
}
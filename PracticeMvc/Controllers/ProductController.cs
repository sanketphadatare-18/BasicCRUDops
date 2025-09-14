using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_layer;
using Service_layer.Impli;
using ViewModel;

namespace WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryServieces _categoryservvices;
        public ProductController(IProductService productService, ICategoryServieces categoryservvices)
        {
            _productService = productService;
            _categoryservvices = categoryservvices;
        }



        public IActionResult Index()
        {
            var product = _productService.GetAll();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryservvices.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel productModel)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Categories = _categoryservvices.GetAll();
                return View(productModel);
            }
            _productService.Create(productModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        { 
           var product = _productService.GetbyId(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _categoryservvices.GetAll();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Categories = _categoryservvices.GetAll();
                return View(productModel);
            }

            var existingProduct = _productService.GetbyId(productModel.id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productService.Update(productModel);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var products = _productService.GetbyId(id);
            return View(products);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetbyId(id);
            return View(product);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetbyId(id);

            if (product == null)
            {
                return NotFound(); // If the product doesn't exist, return 404.
            }

            try
            {
                _productService.Delete(product.id);
                return RedirectToAction("Index"); // Redirect after successful deletion.
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error deleting product. Please try again.");
                Console.WriteLine(ex.Message); // Log the exception
                return View("Delete", product); // Show the delete page again.
            }
        }

        



    }
}

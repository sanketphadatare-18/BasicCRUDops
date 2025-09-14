using AutoMapper;
using AutoMapper.Configuration;
using Dal_Layer;
using Microsoft.AspNetCore.Mvc;
using Service_layer;
using ViewModel;

namespace WebUi.Controllers
{
    public class CategoryController : Controller
    {
       private readonly ICategoryServieces _catserv;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryServieces catserv, IMapper mapper)
        {
            _catserv = catserv;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var categories = _catserv.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel categoryModel)
        {
            if (!ModelState.IsValid) // Validate ModelState before saving
            {
                return View(categoryModel); // Return the form with validation errors
            }

            _catserv.Create(categoryModel); // Call service layer to save category
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Details")]
        public IActionResult GetById(int Id)
        {
            if(Id == null)
            {
                return View();
            }
            var category = _catserv.GetbyId(Id);
            var categoryModel = _mapper.Map<CategoryModel>(category);
            return View(categoryModel);

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound(); // Return a 404 if no ID is provided
            }

            var category = _catserv.GetbyId(Id);

            if (category == null)
            {
                return NotFound(); // Return 404 if the category is not found
            }

            var categoryModel = _mapper.Map<CategoryModel>(category);
            return View(categoryModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category)
        {
            if (category == null)
            {
                return View();
            }

            if (ModelState.IsValid)
            {

                _catserv.Update(_mapper.Map<CategoryModel>(category));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return null;
            }
            var delete = _catserv.GetbyId(id);

            var deleted = _mapper.Map<CategoryModel>(delete);
            return View(deleted);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _catserv.Delete(id);
            return RedirectToAction("Index");
        }

    }

}

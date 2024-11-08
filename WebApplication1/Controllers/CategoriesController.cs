using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)
        {
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id ?? 0);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Add()
        {
			ViewBag.Action = "add";
			return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
			if (ModelState.IsValid)
			{
				CategoriesRepository.AddCategory(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

        public IActionResult Delete(int categaryId)
        {
            CategoriesRepository.DeleteCategory(categaryId);
            return RedirectToAction(nameof(Index));
        }

    }
}

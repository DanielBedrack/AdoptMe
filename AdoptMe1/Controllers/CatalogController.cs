using AdoptMe1.Models;
using AdoptMe1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdoptMe1.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _repository;

        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> CatalogPage()
        {
            ViewBag.Category = await _repository.GetCategoriesAsync();
            return View(await _repository.GetAnimalsAsync());
        }
        public async Task<IActionResult> ShowByCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.Category = await _repository.GetCategoriesAsync();
                    return View("CatalogPage", await _repository.GetAnimalsAsync());
                }
                ViewBag.Category = await _repository.GetCategoriesAsync();
                return View("CatalogPage", await _repository.GetAnimalsByCategoryAsync(id));
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }
        [HttpPost]
        public IActionResult AddComment(string newComment, int animalid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (newComment != null)
                    {
                        _repository.InsertComment(new Comment() { AnimalId = animalid, Comments = newComment });
                        return RedirectToAction("ShowDetails", new { id = animalid });
                    }
                    else
                        return RedirectToAction("ShowDetails", new { id = animalid });
                }
                return RedirectToAction("ShowDetails", new { id = animalid });
            }     
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> ShowDetails(int id)
        {
            try
            {
                var animal = await _repository.GetAnimalByIdAsync(id);
                ViewBag.Animal = animal;
                if(animal != null)
                {
                    ViewBag.Comments = await _repository.GetCommentsByAnimalAsync(animal);
                    return View(animal);
                }
                return View();
            }        
            catch (Exception ex)
            {
                return View(ex);
            }
        }

    }
}

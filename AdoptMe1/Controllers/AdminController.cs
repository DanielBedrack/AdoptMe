using AdoptMe1.Data;
using AdoptMe1.Models;
using AdoptMe1.Repositories;
using AdoptMe1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AdoptMe1.Controllers
{
    [Authorize(Roles = "Administrators")]
 // [ValidateAntiForgeryToken]
    public class AdminController : Controller
    {
        private IRepository _repository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(IRepository repository, IWebHostEnvironment webHost)
        {
            _repository = repository;
            webHostEnvironment= webHost;

        }

        public async Task<IActionResult> AdminPage()
        {
            try
            {
                ViewBag.Category = await _repository.GetCategoriesAsync();
                return View(await _repository.GetAnimalsAsync());
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateAnimal()
        {
            try
            {
                ViewBag.Category = await _repository.GetCategoriesAsync();
                Animal animal = new();
                return View(animal);
            }                                          
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public IActionResult SaveAnimal(Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string? uniqueFileName = null;
                    if (animal.Image != null)
                    {
                        string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + animal.Image.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);
                        animal.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                    Animal newAnimal = animal;
                    newAnimal.ImageString = uniqueFileName;

                    _repository.InsertAnimal(newAnimal);
                    return RedirectToAction("AdminPage");
                }
                return RedirectToAction("CreateAnimal");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditPage(int Id)
        {
            try
            {
                Animal animal = _repository.GetAnimalById(Id);
                ViewBag.Category = await _repository.GetCategoriesAsync();
                return View(animal);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpPost]
        public IActionResult EditPage(int Id, Animal animal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateAnimal(Id, animal);
                    return RedirectToAction("AdminPage");
                }
                return RedirectToAction("AdminPage");
            }           
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public IActionResult DeleteAnimal(string name)
        {
            try
            {
                var animal = _repository.GetAnimalByName(name);
                _repository.DeleteAnimal(animal.AnimalId);
                return RedirectToAction("AdminPage");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> ShowByCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    ViewBag.Category = await _repository.GetCategoriesAsync();
                    return View("AdminPage", await _repository.GetAnimalsAsync());
                }
                ViewBag.Category = await _repository.GetCategoriesAsync();
                return View("AdminPage", _repository.GetAnimalsByCategory(id));
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
    }
}

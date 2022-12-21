using AdoptMe1.Data;
using AdoptMe1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdoptMe1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult HomePage()
        {
            ViewBag.TopTwo = _repository.GetTopTwo();  
            return View();
        }
    }
}

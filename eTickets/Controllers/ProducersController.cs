using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {

        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task <IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //GET: Producers/details/1
        public async Task <IActionResult>Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            else return View(productDetails);
        }
        //GET:Producers/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer )
        {
            if (!ModelState.IsValid) return View(producer);
            else
                await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
            
    }
}

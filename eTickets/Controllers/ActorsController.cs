using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        private IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public ActorsController(IActorsService service, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _service = service;
            _environment = environment;
            _configuration = configuration;
        }
        public async Task <IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get : Actors/Create 
        //removed the task because we don't have any data manipulation
         public IActionResult Create ()
        {
            return View();
        }
        
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL","FullName", "Bio")] Actor actor, IFormFile postedFile)
        {
           
           

            string wwwPath = this._environment.WebRootPath;
            string contentPath = this._environment.ContentRootPath;
            String folderName =  this._configuration.GetValue<string>("uploadFolder");

            string path = Path.Combine(this._environment.WebRootPath, folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(postedFile.FileName);
            string imageUrl = "/"+folderName+"/" + fileName;
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    imageUrl = "Uploads/" + fileName;
                    actor.ProfilePictureURL = imageUrl;

                }
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task <IActionResult> Details (int id )
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");
            return View (actorDetails);
        }
    }
}

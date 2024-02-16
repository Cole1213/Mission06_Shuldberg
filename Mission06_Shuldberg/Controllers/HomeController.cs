using Microsoft.AspNetCore.Mvc;
using Mission06_Shuldberg.Models;
using System.Diagnostics;

namespace Mission06_Shuldberg.Controllers
{
    public class HomeController : Controller
    {
        //Set up the constructor
        private MovieContext _context;

        public HomeController(MovieContext temp)
        {
            _context = temp;
        }

        //Return home page
        public IActionResult Index()
        {
            return View();
        }

        //Return about page
        public IActionResult GetToKnow()
        {
            return View();
        }

        //Return Add Movie page
        [HttpGet]
        public IActionResult AddMovie()
        { 
            return View(); 
        }

        //Post form data from Add Movie page to sqlite database
        [HttpPost]
        public IActionResult AddMovie(Class response)
        {
            _context.Movies.Add(response);
            _context.SaveChanges();

            return View();
        }

    }
}

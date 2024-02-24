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
            ViewBag.Categories = _context.Categories.ToList();

            return View("AddMovie", new Class()); 
        }

        //Post form data from Add Movie page to sqlite database
        [HttpPost]
        public IActionResult AddMovie(Class response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return RedirectToAction("MovieDB");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();

                return View(response);
            }
        }

        public IActionResult MovieDB()
        {
            //Linq
            var movieData = _context.Movies
                .OrderBy(x => x.Title).ToList();

            ViewBag.Categories = _context.Categories.ToList();

            return View(movieData);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var recordToEdit = _context.Movies.Single(x => x.MovieId == Id);

            ViewBag.Categories = _context.Categories.ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Class updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieDB");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(y => y.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Class movie)
        {
            _context.Movies.Remove(movie); 
            _context.SaveChanges();

            return RedirectToAction("MovieDB");
        }
    }
}

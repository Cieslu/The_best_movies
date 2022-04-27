using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using najlepsze_filmy.Data;
using najlepsze_filmy.Models;

namespace najlepsze_filmy.Controllers
{
    public class AddMovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AddMovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            ViewBag.GenreId = new SelectList(_db.Genres, "Id", "Name");            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMovie(Movie element)
        {
            if (ModelState.IsValid)
            {
                await _db.Movies.AddAsync(element);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.GenreId = new SelectList(_db.Genres, "Id", "Name");
            return View();
        }
    }
}

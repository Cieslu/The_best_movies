using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using najlepsze_filmy.Data;
using System.Text.RegularExpressions;
using najlepsze_filmy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
#nullable disable

namespace najlepsze_filmy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index(Movie m)
        {      
            var movieList = _db.Movies.ToList();
            return View(movieList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movieDetails == null)
            {
                return NotFound();
            }

            var movieGenre = await _db.Genres.FindAsync(movieDetails.GenreId);

            if (movieDetails.GenreId == movieGenre.Id)
            {
                ViewBag.genreMovie = movieGenre.Name;
            }

            var comCount = _db.Comments.Where(x => x.MovieId == movieDetails.Id).Count();
            ViewBag.comCount = comCount;

            movieDetails.CommentsMovie = _db.Comments.Where(x => x.MovieId == movieDetails.Id).ToList();
            return View(movieDetails);
        }
    }
}

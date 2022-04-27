using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using najlepsze_filmy.Data;
using najlepsze_filmy.Models;

namespace najlepsze_filmy.Controllers
{
    public class AddCommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AddCommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult CreateComment(int? id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(int? id, Comment element)
        {
            if (ModelState.IsValid) 
            { 
                var var1 = await _db.Movies.FirstOrDefaultAsync(x => x.Id == id);

                if(var1 == null)
                {
                    return NotFound();
                }

                var comment = new Comment()
                {
                    Name = element.Name,
                    Description = element.Description,
                    MovieId = var1.Id,
                };

                if (comment == null)
                {
                    return NotFound();
                }

                await _db.Comments.AddAsync(comment);
                await _db.SaveChangesAsync();               
                return RedirectToAction("Details", "Home", new { id });

            }
            return View();
        } 
    }
}

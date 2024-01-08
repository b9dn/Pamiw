using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Services.FilmService;
using P06Shop.Shared.Shop;


namespace P09ShopWebAPPMVC.Client.Controllers
{
    public class FilmsAPIController : Controller
    {
      
        private readonly IFilmService _filmService;

        public FilmsAPIController(IFilmService filmService)
        {
            _filmService = filmService;
          
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            var films = await _filmService.GetFilmsAsync();
            return films != null ?
                          View(films.Data.AsEnumerable()) :
                          Problem("Entity set 'ShopContext.Films'  is null.");

            //return films != null ? 
            //              View("~/Views/Films/Index.cshtml", films.Data.AsEnumerable()) :
            //              Problem("Entity set 'ShopContext.Films'  is null.");
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }
            var film = await _filmService.GetFilmByIdAsync((int)id);
            
            if (film.Data == null)
            {
                return NotFound();
            }

            return View(film.Data);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Barcode,Price,ReleaseDate")] Film film)
        {
             
            if (ModelState.IsValid)
            {
                await _filmService.CreateFilmAsync(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var film =await _filmService.GetFilmByIdAsync((int)id);
            if (film.Data == null)
            {
                return NotFound();
            }
            return View(film.Data);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Barcode,Price,ReleaseDate")] Film film)
        {

            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var filmResult = await _filmService.UpdateFilmAsync(film);
                }
                catch (Exception)
                {
                     return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var film = await _filmService.GetFilmByIdAsync((int)id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film.Data);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _filmService.DeleteFilmAsync((int)id);
            if (film.Success)
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
          
        }
         
    }
}

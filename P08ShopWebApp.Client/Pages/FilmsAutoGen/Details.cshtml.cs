using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using P08ShopWebApp.Client.Data;
using P08ShopWebApp.Client.Models;

namespace P08ShopWebApp.Client.Pages.FilmsAutoGen
{
    public class DetailsModel : PageModel
    {
        private readonly P08ShopWebApp.Client.Data.ShopContext _context;

        public DetailsModel(P08ShopWebApp.Client.Data.ShopContext context)
        {
            _context = context;
        }

      public Film Film { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Films == null)
            {
                return NotFound();
            }

            var film = await _context.Films.FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            else 
            {
                Film = film;
            }
            return Page();
        }
    }
}

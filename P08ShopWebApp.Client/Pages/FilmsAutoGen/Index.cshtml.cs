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
    public class IndexModel : PageModel
    {
        private readonly P08ShopWebApp.Client.Data.ShopContext _context;

        public IndexModel(P08ShopWebApp.Client.Data.ShopContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Films != null)
            {
                Film = await _context.Films.ToListAsync();
            }
        }
    }
}

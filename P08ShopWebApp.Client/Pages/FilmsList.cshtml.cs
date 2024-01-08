using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using P08ShopWebApp.Client.Data;
using P08ShopWebApp.Client.Models;

namespace P08ShopWebApp.Client.Pages
{
    public class FilmsListModel : PageModel
    {
        private readonly ShopContext _context;

        public List<Film> Films { get; set; }

        public FilmsListModel(ShopContext context)
        {
            _context = context;
        }

        public void OnGet()
        { 
            Films = _context.Films.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FootballDirectory.Data;
using FootballDirectory.Models;

namespace FootballDirectory.Pages.Stadiums
{
    public class DeleteModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public DeleteModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stadium Stadium { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadium = await _context.Stadiums.FirstOrDefaultAsync(m => m.StadiumID == id);

            if (stadium == null)
            {
                return NotFound();
            }
            else 
            {
                Stadium = stadium;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }
            var stadium = await _context.Stadiums.FindAsync(id);

            if (stadium != null)
            {
                Stadium = stadium;
                _context.Stadiums.Remove(Stadium);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

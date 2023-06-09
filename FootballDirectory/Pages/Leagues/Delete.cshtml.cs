using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FootballDirectory.Data;
using FootballDirectory.Models;

namespace FootballDirectory.Pages.Leagues
{
    public class DeleteModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public DeleteModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

        [BindProperty]
      public League League { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues.FirstOrDefaultAsync(m => m.LeagueID == id);

            if (league == null)
            {
                return NotFound();
            }
            else 
            {
                League = league;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }
            var league = await _context.Leagues.FindAsync(id);

            if (league != null)
            {
                League = league;
                _context.Leagues.Remove(League);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

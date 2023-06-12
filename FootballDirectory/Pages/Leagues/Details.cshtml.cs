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
    public class DetailsModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public DetailsModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

      public League League { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Leagues == null)
            {
                return NotFound();
            }

            var league = await _context.Leagues
                .Include(t => t.Teams)
                .FirstOrDefaultAsync(m => m.LeagueID == id);

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
    }
}

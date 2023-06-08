using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FootballDirectory.Data;
using FootballDirectory.Models;

namespace FootballDirectory.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public DetailsModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

      public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.TeamID == id);
            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }
    }
}

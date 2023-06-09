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
    public class DetailsModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public DetailsModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

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
    }
}

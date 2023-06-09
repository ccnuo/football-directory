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
    public class IndexModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public IndexModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

        public IList<League> League { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Leagues != null)
            {
                League = await _context.Leagues.ToListAsync();
            }
        }
    }
}

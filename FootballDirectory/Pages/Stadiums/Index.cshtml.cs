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
    public class IndexModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public IndexModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

        public IList<Stadium> Stadium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stadiums != null)
            {
                Stadium = await _context.Stadiums.ToListAsync();
            }
        }
    }
}

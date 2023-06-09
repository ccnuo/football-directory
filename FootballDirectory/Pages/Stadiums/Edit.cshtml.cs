using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FootballDirectory.Data;
using FootballDirectory.Models;

namespace FootballDirectory.Pages.Stadiums
{
    public class EditModel : PageModel
    {
        private readonly FootballDirectory.Data.TeamContext _context;

        public EditModel(FootballDirectory.Data.TeamContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stadium Stadium { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stadiums == null)
            {
                return NotFound();
            }

            var stadium =  await _context.Stadiums.FirstOrDefaultAsync(m => m.StadiumID == id);
            if (stadium == null)
            {
                return NotFound();
            }
            Stadium = stadium;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Stadium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumExists(Stadium.StadiumID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StadiumExists(int id)
        {
          return _context.Stadiums.Any(e => e.StadiumID == id);
        }
    }
}

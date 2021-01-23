using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideoGameDB.Data;
using RazorPagesVideoGameDB.Models;

namespace RazorPagesVideoGameDB.Pages.VideoGame
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext _context;

        public EditModel(RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VideoGameModel VideoGameModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VideoGameModel = await _context.VideoGameModel.FirstOrDefaultAsync(m => m.Id == id);

            if (VideoGameModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VideoGameModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGameModelExists(VideoGameModel.Id))
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

        private bool VideoGameModelExists(int id)
        {
            return _context.VideoGameModel.Any(e => e.Id == id);
        }
    }
}

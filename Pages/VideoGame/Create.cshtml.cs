using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesVideoGameDB.Data;
using RazorPagesVideoGameDB.Models;

namespace RazorPagesVideoGameDB.Pages.VideoGame
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext _context;

        public CreateModel(RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VideoGameModel VideoGameModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VideoGameModel.Add(VideoGameModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

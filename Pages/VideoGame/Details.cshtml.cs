using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideoGameDB.Data;
using RazorPagesVideoGameDB.Models;

namespace RazorPagesVideoGameDB.Pages.VideoGame
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext _context;

        public DetailsModel(RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext context)
        {
            _context = context;
        }

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
    }
}

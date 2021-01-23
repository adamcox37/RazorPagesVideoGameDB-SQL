using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideoGameDB.Data;
using RazorPagesVideoGameDB.Models;

namespace RazorPagesVideoGameDB.Pages.VideoGame
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext _context;

        public IndexModel(RazorPagesVideoGameDB.Data.RazorPagesVideoGameDBContext context)
        {
            _context = context;
        }

        public IList<VideoGameModel> VideoGameModel { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Platform { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameConsole { get; set; }

        public async Task OnGetAsync()
        {
            //  Use LINQ to get list of Platforms
            IQueryable<string> platformQuery = from p in _context.VideoGameModel
                                               orderby p.Platform
                                               select p.Platform;

            var game = from g in _context.VideoGameModel
                       select g;

            if (!string.IsNullOrEmpty(SearchString))
            {
                game = game.Where(s => s.GameTitle.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(GameConsole))
            {
                game = game.Where(x => x.Platform == GameConsole);
            }

            Platform = new SelectList(await platformQuery.Distinct().ToListAsync());

            VideoGameModel = await game.ToListAsync();
        }
    }
}

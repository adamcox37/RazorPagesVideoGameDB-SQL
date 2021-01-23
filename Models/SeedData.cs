using RazorPagesVideoGameDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesVideoGameDB.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesVideoGameDBContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesVideoGameDBContext>>()))
            {
                // Look for any game
                if (context.VideoGameModel.Any())
                {
                    return; // DB has been seeded
                }

                context.VideoGameModel.AddRange( 
                    new VideoGameModel 
                    { 
                        GameTitle = "Doom",
                        ReleaseYear = "1994",
                        Platform = "Sega 32X",
                        Publisher = "Id Software",
                        CompleteCopy = "Cartridge Only",
                        PhysicalCopy = "Yes"
                    });

                context.SaveChanges();
            }
        }
    }
}

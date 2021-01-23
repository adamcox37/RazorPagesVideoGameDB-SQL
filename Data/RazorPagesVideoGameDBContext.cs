using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesVideoGameDB.Models;

namespace RazorPagesVideoGameDB.Data
{
    public class RazorPagesVideoGameDBContext : DbContext
    {
        public RazorPagesVideoGameDBContext (DbContextOptions<RazorPagesVideoGameDBContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesVideoGameDB.Models.VideoGameModel> VideoGameModel { get; set; }
    }
}

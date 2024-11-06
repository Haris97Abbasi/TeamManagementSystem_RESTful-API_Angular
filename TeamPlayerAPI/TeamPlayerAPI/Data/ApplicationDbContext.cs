using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeamPlayerAPI.Models;

namespace TeamPlayerAPI.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            public DbSet<Player> Players { get; set; }
        }
}

using Microsoft.EntityFrameworkCore;
using PaginationModel.Models;
using System.Collections.Generic;

namespace PaginationModel.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}

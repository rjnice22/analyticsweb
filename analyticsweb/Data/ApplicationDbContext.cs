using analyticsweb.Models; // <-- add this so DbSet<Dataset> is recognized
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace analyticsweb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // App tables
        public DbSet<Dataset> Datasets { get; set; } = default!;
    }
}

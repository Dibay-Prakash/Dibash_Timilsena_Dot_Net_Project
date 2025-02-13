using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessTracker.Models;

namespace FitnessTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FitnessTracker.Models.Fitness> Fitness { get; set; } = default!;
        public DbSet<FitnessTracker.Models.Track> Track { get; set; } = default!;
    }
}

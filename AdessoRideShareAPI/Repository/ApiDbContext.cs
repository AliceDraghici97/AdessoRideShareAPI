using AdessoRideShareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace AdessoRideShareAPI.Repository
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TravelPlan>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        public virtual DbSet<TravelPlan> TravelPlans { get; set; } = null!;
    }
}

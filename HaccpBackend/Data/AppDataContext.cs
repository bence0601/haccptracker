using HaccpBackend.Domain.CheckItems;
using HaccpBackend.Domain.Organizations;
using HaccpBackend.Domain.Users;
using HaccpBackend.Domain.Vendors;
using Microsoft.EntityFrameworkCore;

namespace HaccpBackend.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<VendorUserAccess> VendorUserAccesses { get; set; }
        public DbSet<CheckItem> CheckItems { get; set; }
        public DbSet<ActualCheckItem> ActualCheckItems { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        

    }
}
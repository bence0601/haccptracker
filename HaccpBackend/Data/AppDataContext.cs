using HaccpBackend.Domain.CheckItems;
using HaccpBackend.Domain.Logs;
using HaccpBackend.Domain.Organizations;
using HaccpBackend.Domain.Users;
using HaccpBackend.Domain.Vendors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HaccpBackend.Data
{
    public class AppDataContext : IdentityDbContext<User,IdentityRole<int>, int>
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<VendorUserAccess> VendorUserAccesses { get; set; }
        public DbSet<CheckItem> CheckItems { get; set; }
        public DbSet<ActualCheckItem> ActualCheckItems { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<ActualLog> ActualLogs { get; set; }


        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActualCheckItem>()
                .HasDiscriminator<CheckItemType>("CheckItemType")
                .HasValue<BooleanCheckItem>(CheckItemType.Boolean)
                .HasValue<NumericCheckItem>(CheckItemType.Numeric)
                .HasValue<TextCheckItem>(CheckItemType.FreeText);
        }

    }
}
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data
{
    class AppDBContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=RegionDB;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Region>()
                    .ToTable("Region")
                    //.HasDiscriminator();
                    .HasDiscriminator<string>("RegionType");

            modelBuilder.Entity<Region>()
                    .Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(255);

            modelBuilder.Entity<Region>()
                .HasOne(r => r.Parent)
                .WithMany()
                .HasForeignKey(r => r.ParentId)
                .IsRequired(false);
        }
    }
}

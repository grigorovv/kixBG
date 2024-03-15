using kixBG.Infrastructure.Data.Entities;
using kixBG.Infrastructure.Data.SeedDB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kixBG.Infrastructure.Data
{
    public class MainDbContext : IdentityDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClotheCategoryConfiguration());
            builder.ApplyConfiguration(new ClothesConfiguration());
            builder.ApplyConfiguration(new ShoesConfiguration());


            base.OnModelCreating(builder);
        }

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Clothe> Clothes { get; set; } = null!;
        public DbSet<ClotheCategory> ClotheCategories { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Seller> Sellers { get; set; } = null!;
        public DbSet<Shoe> Shoes { get; set; } = null!;
    }
}
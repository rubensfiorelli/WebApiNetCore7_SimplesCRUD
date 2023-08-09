using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Data.DatabaseContext
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.ApplyConfigurationsFromAssembly(typeof(OakleyDbContext).Assembly);
        }



    }

}

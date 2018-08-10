using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TTA.Api.Models;

namespace TTA.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)

        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderTracking> OrderTrackings { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OptionList> OptionLists { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasKey(m => m.Id);
            builder.Entity<OrderTracking>().HasKey(m => m.Id);
            builder.Entity<Product>().HasKey(m => m.Id);
            builder.Entity<OptionList>().HasKey(m => m.Id);
            builder.Entity<Supplier>().HasKey(m => m.Id);


            // shadow properties - log date time record been updated
            builder.Entity<Order>().Property<DateTime>("updated_timestamp");
            builder.Entity<OrderItem>().Property<DateTime>("updated_timestamp");
            builder.Entity<OrderTracking>().Property<DateTime>("updated_timestamp");
            builder.Entity<Product>().Property<DateTime>("updated_timestamp");
            builder.Entity<OptionList>().Property<DateTime>("updated_timestamp");
            builder.Entity<Supplier>().Property<DateTime>("updated_timestamp");

            builder.Entity<Product>().Property(b => b.Created).ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(b => b.Created).ValueGeneratedOnAdd();          
            builder.Entity<Supplier>().Property(b => b.Created).ValueGeneratedOnAdd();

            //relationship
            builder.Entity<OrderItem>().HasOne(i => i.Order).WithMany(o => o.OrderItems);//1 order has many order items


            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            //remember to update UpdatedTimestamp when call savechanges
            updateUpdatedProperty<Order>();
            updateUpdatedProperty<OrderTracking>();
            updateUpdatedProperty<OrderItem>();
            updateUpdatedProperty<Product>();
            updateUpdatedProperty<OptionList>();
            updateUpdatedProperty<Supplier>();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            //remember to update UpdatedTimestamp when call savechanges
            updateUpdatedProperty<Order>();
            updateUpdatedProperty<OrderTracking>();
            updateUpdatedProperty<OrderItem>();
            updateUpdatedProperty<Product>();
            updateUpdatedProperty<OptionList>();
            updateUpdatedProperty<Supplier>();

            return (await base.SaveChangesAsync(true, cancellationToken));
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("updated_timestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
    
}

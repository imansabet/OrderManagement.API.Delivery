using Microsoft.EntityFrameworkCore;
using OrderManagement.API.Delivery.INfrastructure.Entities;

namespace OrderManagement.API.Delivery.INfrastructure.Configuration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = Guid.Parse("f7948d66-ae41-4a2b-8a41-a5dea5750243"), Name = "Customer1", Email = "customer1@email.com", Address = "Address1", PhoneNumber = "1234567890" },
                new Customer { Id = Guid.Parse("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), Name = "Customer2", Email = "customer2@email.com", Address = "Address2", PhoneNumber = "9876543210" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = Guid.NewGuid(), Description = "Order1", CustomerId = Guid.Parse("f7948d66-ae41-4a2b-8a41-a5dea5750243"), CreateDate = DateTime.Now, TotalAmount = 100.00m },
                new Order { Id = Guid.NewGuid(), Description = "Order2", CustomerId = Guid.Parse("f7948d66-ae41-4a2b-8a41-a5dea5750243"), CreateDate = DateTime.Now, TotalAmount = 150.50m },
                new Order { Id = Guid.NewGuid(), Description = "Order3", CustomerId = Guid.Parse("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), CreateDate = DateTime.Now, TotalAmount = 75.25m }
            );

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
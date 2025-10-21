using Microsoft.EntityFrameworkCore;
using StoreApi.Models.Entities;

namespace StoreApi;

public class StoreDbContext : DbContext
{
    public DbSet<Order> Order { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
        
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OrderProduct>().HasKey(p => new {p.ProducdId, p.OrderId});

        modelBuilder.Entity<SystemUser>().HasData(
            new SystemUser
        {
            Id = 1,
            FirstName = "Juan",
            LastName = "Juan",
            Email = "juan@gmail.com",
            Password = "123456"
                
        });
        
        modelBuilder.Entity<Store>().HasData(
            new Store { Id = 1, Description = "Plaza Mayor León", Latitude = 21.1540, Longitude = -101.6946 },
            new Store { Id = 2, Description = "Centro Max", Latitude = 21.0948, Longitude = -101.6417 },
            new Store { Id = 3, Description = "Plaza Galerías Las Torres", Latitude = 21.1211, Longitude = -101.6613 },
            new Store { Id = 4, Description = "Outlet Mulza", Latitude = 21.0459, Longitude = -101.5862 },
            new Store { Id = 5, Description = "La Gran Plaza León", Latitude = 21.1280, Longitude = -101.6827 },
            new Store { Id = 6, Description = "Altacia", Latitude = 21.1280, Longitude = -102 }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Zapatos de piel", Description = "Calzado típico de León", Price = 1200, StoreId = 4 },
            new Product { Id = 2, Name = "Bolsa de cuero", Description = "Artesanía local", Price = 950, StoreId = 4 },
            new Product { Id = 3, Name = "Hamburguesa doble", Description = "Comida rápida", Price = 120, StoreId = 1 },
            new Product { Id = 4, Name = "Pizza familiar", Description = "Especialidad italiana", Price = 220, StoreId = 2 },
            new Product { Id = 5, Name = "Café americano", Description = "Taza grande", Price = 45, StoreId = 3 },
            new Product { Id = 6, Name = "Refresco 600ml", Description = "Bebida refrescante", Price = 20, StoreId = 5 }
        );
        
        modelBuilder.Entity<Invoice>().HasData(
            new Invoice
            {
                Id = 1,
                OrderId = 1,
                InvoiceNumber = "INV-1001",
                IssueDate = DateTime.Now.AddDays(-10),
                DueDate = DateTime.Now.AddDays(20),
                Subtotal = 1000,
                Tax = 160,
                Total = 1160,
                Currency = "MXN",
                IsPaid = false,
                PaymentDate = null,
                BillingName = "Juan Pérez",
                BillingAddress = "Calle Falsa 123, León",
                BillingEmail = "juan.perez@gmail.com",
                TaxId = "XAXX010101000",
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = null
            },
            new Invoice
            {
                Id = 2,
                OrderId = 1,
                InvoiceNumber = "INV-1002",
                IssueDate = DateTime.Now.AddDays(-5),
                DueDate = DateTime.Now.AddDays(25),
                Subtotal = 500,
                Tax = 80,
                Total = 580,
                Currency = "MXN",
                IsPaid = true,
                PaymentDate = DateTime.Now.AddDays(-1),
                BillingName = "Juan Pérez",
                BillingAddress = "Calle Falsa 123, León",
                BillingEmail = "juan.perez@gmail.com",
                TaxId = "XAXX010101000",
                CreatedAt = DateTime.Now.AddDays(-5),
                UpdatedAt = DateTime.Now
            },
            new Invoice
            {
                Id = 3,
                OrderId = 2,
                InvoiceNumber = "INV-1003",
                IssueDate = DateTime.Now.AddDays(-3),
                DueDate = DateTime.Now.AddDays(27),
                Subtotal = 1200,
                Tax = 192,
                Total = 1392,
                Currency = "MXN",
                IsPaid = false,
                PaymentDate = null,
                BillingName = "María López",
                BillingAddress = "Av. Central 45, León",
                BillingEmail = "maria.lopez@gmail.com",
                TaxId = "XEXX010101000",
                CreatedAt = DateTime.Now.AddDays(-3),
                UpdatedAt = null
            }
        );

    }
}
using Microsoft.EntityFrameworkCore;

namespace Lab11
{
  public class DemoContext : DbContext
  {
    public DemoContext() { }
    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Detail> Details { get; set; }
  }
}
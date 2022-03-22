using Domain;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AssignmentDbContext : DbContext
{
    public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<PromotionProgram> PromotionPrograms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new PackageMap());
        modelBuilder.ApplyConfiguration(new PromotionMap());
        modelBuilder.ApplyConfiguration(new PromotionProgramMap());

        base.OnModelCreating(modelBuilder);

        DataSeeding.SeedData(modelBuilder);
    }
}

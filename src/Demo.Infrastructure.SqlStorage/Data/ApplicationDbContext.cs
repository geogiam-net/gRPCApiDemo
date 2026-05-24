using Microsoft.EntityFrameworkCore;
using Demo.Business.Models;
using System.Linq;

namespace Demo.Infrastructure.SqlStorage.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public const string DbSchema = "DemoApp";
    public DbSet<Corporation> Corporations => Set<Corporation>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Locations> Locations => Set<Locations>();
    public DbSet<Employee> Employees => Set<Employee>();

    // in memory database won't call this method
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);

        // Configure relationships
        modelBuilder.Entity<Corporation>(b =>
        {
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Companies).WithOne(cmp => cmp.Corporation).HasForeignKey(cmp => cmp.CorporationId);
            b.HasMany(c => c.Locations).WithOne(l => l.Corporation).HasForeignKey(l => l.CorporationId);
        });

        modelBuilder.Entity<Company>(b =>
        {
            b.HasKey(c => c.Id);
            b.HasMany(c => c.Employees).WithOne(e => e.Company).HasForeignKey(e => e.CompanyId);
        });

        modelBuilder.Entity<Locations>(b =>
        {
            b.HasKey(l => l.Id);
        });

        modelBuilder.Entity<Employee>(b =>
        {
            b.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }

    public static void CreateSeedData(ApplicationDbContext context)
    {
        // Avoid seeding when data already exists
        if (context.Corporations.Any())
            return;

        // Seed data
        var corp1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var corp2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

        var company1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var company2Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var company3Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

        var location1Id = Guid.Parse("66666666-6666-6666-6666-666666666666");
        var location2Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        var location3Id = Guid.Parse("88888888-8888-8888-8888-888888888888");

        var emp1Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
        var emp2Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        var emp3Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
        var emp4Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

        var corporations = new[]
        {
            new Corporation { Id = corp1Id, LegalName = "Acme Holdings" },
            new Corporation { Id = corp2Id, LegalName = "Contoso Group" }
        };

        var companies = new[]
        {
            new Company { Id = company1Id, LegalName = "Acme Manufacturing", EarningsLastYear = 1_000_000m, RevenueLastYear = 5_000_000m, CreationDate = new DateTime(2000, 1, 1), CorporationId = corp1Id },
            new Company { Id = company2Id, LegalName = "Acme Logistics", EarningsLastYear = 200_000m, RevenueLastYear = 800_000m, CreationDate = new DateTime(2005, 6, 1), CorporationId = corp1Id },
            new Company { Id = company3Id, LegalName = "Contoso Retail", EarningsLastYear = 500_000m, RevenueLastYear = 2_000_000m, CreationDate = new DateTime(2010, 3, 15), CorporationId = corp2Id }
        };

        var locations = new[]
        {
            new Locations { Id = location1Id, Number = "1", Street = "Main St", City = "Metropolis", ZipCode = "10001", IsHeadquarters = true, IsLeased = false, CorporationId = corp1Id },
            new Locations { Id = location2Id, Number = "10", Street = "2nd Ave", City = "Gotham", ZipCode = "20002", IsHeadquarters = false, IsLeased = true, CorporationId = corp1Id },
            new Locations { Id = location3Id, Number = "5", Street = "Commerce Blvd", City = "Springfield", ZipCode = "30003", IsHeadquarters = true, IsLeased = false, CorporationId = corp2Id }
        };

        var employees = new[]
        {
            new Employee { Id = emp1Id, DocumentId = "ID1001", Name = "John", Lastname = "Doe", Salary = 70000m, BirthDate = new DateTime(1985, 4, 12), Role = Role.Management, CompanyId = company1Id },
            new Employee { Id = emp2Id, DocumentId = "ID1002", Name = "Jane", Lastname = "Smith", Salary = 60000m, BirthDate = new DateTime(1990, 7, 23), Role = Role.Operations, CompanyId = company1Id },
            new Employee { Id = emp3Id, DocumentId = "ID2001", Name = "Bob", Lastname = "Johnson", Salary = 50000m, BirthDate = new DateTime(1992, 11, 3), Role = Role.Operations, CompanyId = company2Id },
            new Employee { Id = emp4Id, DocumentId = "ID3001", Name = "Alice", Lastname = "Williams", Salary = 80000m, BirthDate = new DateTime(1980, 2, 28), Role = Role.Management, CompanyId = company3Id }
        };

        context.Corporations.AddRange(corporations);
        context.Companies.AddRange(companies);
        context.Locations.AddRange(locations);
        context.Employees.AddRange(employees);

        context.SaveChanges();
    }
}

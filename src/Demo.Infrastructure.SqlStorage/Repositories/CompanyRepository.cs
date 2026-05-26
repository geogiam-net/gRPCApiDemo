using Microsoft.EntityFrameworkCore;
using Demo.Business.Interfaces;
using Demo.Business.Models;
using Demo.Infrastructure.SqlStorage.Data;

namespace Demo.Infrastructure.SqlStorage.Services;

public class CompanyRepository(ApplicationDbContext dbContext) : ICompanyRepository
{
    public async Task<Company?> GetCompanyDataAsync(string legalName, CancellationToken cancellationToken = default)
    {
        return await dbContext.Companies
            .Include(x => x.Corporation)
            .Include(x => x.Employees)
            .Include(x => x.Locations)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => string.Equals(x.LegalName, legalName, StringComparison.OrdinalIgnoreCase), cancellationToken);
    }

    public async Task<Company?> UpdatePastYearCompanyEarningsAndRevenueAsync(string legalName, decimal newEarnings, decimal newRevenue, CancellationToken cancellationToken = default)
    {
        var company = await dbContext.Companies
            .FirstOrDefaultAsync(x => string.Equals(x.LegalName, legalName, StringComparison.OrdinalIgnoreCase), cancellationToken);

        if (company == null)
        {
            return null;
        }

        company.EarningsLastYear = newEarnings;
        company.RevenueLastYear = newRevenue;   

        await dbContext.SaveChangesAsync(cancellationToken);

        return company;
    }
}
using Demo.Business.Exceptions;
using Demo.Business.Models;

namespace Demo.Business.Interfaces;

public interface ICompanyService
{
    Task<Company?> GetCompanyDataAsync(string legalName, CancellationToken cancellationToken = default);

    Task<Company?> UpdatePastYearCompanyEarningsAndRevenueAsync(string legalName, decimal newEarnings, decimal newRevenue, CancellationToken cancellationToken = default);
}
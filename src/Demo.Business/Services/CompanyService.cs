using Demo.Business.Interfaces;
using Demo.Business.Models;

namespace Demo.Business.Services;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    public async Task<Company?> GetCompanyDataAsync(string legalName, CancellationToken cancellationToken = default)
    {
        return await companyRepository.GetCompanyDataAsync(legalName, cancellationToken);
    }

    public async Task<Company?> UpdateCompanyFinancialsAsync(string legalName, decimal newEarnings, decimal newRevenue, CancellationToken cancellationToken = default)
    {
        return await companyRepository.UpdateCompanyFinancialsAsync(legalName, newEarnings, newRevenue, cancellationToken);
    }
}
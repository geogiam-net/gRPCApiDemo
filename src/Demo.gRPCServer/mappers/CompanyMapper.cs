namespace Demo.gRPCServer.Services;

public static class CompanyMapper
{
    public static Company Map(Business.Models.Company company)
    {
        return new Company
        {
            Id = company.Id.ToString(),
            LegalName = company.LegalName,
            CreationDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(company.CreationDate.ToUniversalTime()),
            EarningsLastYear = (double)company.EarningsLastYear,
            RevenueLastYear = (double)company.RevenueLastYear
        };
    }
}
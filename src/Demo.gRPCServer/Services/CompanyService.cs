using Demo.Business.Interfaces;
using Grpc.Core;

namespace Demo.gRPCServer.Services;

public class CompanyService(ILogger<CompanyService> logger, ICompanyService companyService) : ProtoCompany.ProtoCompanyBase
{
    public override Task<GetCompanyDataResponse> GetCompanyData(GetCompanyDataRequest request, ServerCallContext context)
    {
        logger.LogInformation("The request asks for company with legal name {0}", request.LegalName);

        return Task.Run(
            async () => {
                var response = new GetCompanyDataResponse();

                var company = await companyService.GetCompanyDataAsync(request.LegalName, context.CancellationToken);
                if (company is null)
                {
                    return response;
                }

                response.Company = CompanyMapper.Map(company);

                return response;
            }
        );
    }

    public override Task<UpdateCompanyFinancialsResponse> UpdateCompanyFinancials(UpdateCompanyFinancialsRequest request, ServerCallContext context)
    {
        logger.LogInformation("The request changes company financials with legal name {0}", request.LegalName);

        return Task.Run(
            async () => {
                var response = new UpdateCompanyFinancialsResponse();

                var company = await companyService.UpdateCompanyFinancialsAsync(
                    request.LegalName, 
                    (decimal)request.NewEarnings,
                    (decimal)request.NewRevenue,
                    context.CancellationToken);

                if (company is null)
                {
                    return response;
                }

                response.Company = CompanyMapper.Map(company);

                return response;
            }
        );
    }
}

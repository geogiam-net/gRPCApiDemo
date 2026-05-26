using Demo.Business.Interfaces;
using Grpc.Core;

namespace Demo.gRPCServer.Services;

public class EmployeeService(ILogger<EmployeeService> logger, IEmployeeService employeeService) : ProtoEmployee.ProtoEmployeeBase
{
    public override Task<GetEmployeeByIdResponse> GetEmployeeById(GetEmployeeByIdRequest request, ServerCallContext context)
    {
        logger.LogInformation("The request asks for  employee with Id {0}", request.Id);

        var response = new GetEmployeeByIdResponse();
        if (!Guid.TryParse(request.Id, out var employeeId))
        {
            return Task.FromResult(response);
        }

        return Task.Run(
            async () => {
                var employee = await employeeService.GetEmployeeAsync(employeeId, context.CancellationToken);
                if (employee is null)
                {
                    return response;
                }

                response.Employee = EmployeeMapper.Map(employee);

                return response;
            }
        );
    }

    public override Task<GetEmployeesResponse> GetEmployees(GetEmployeesRequest request, ServerCallContext context)
    {
        logger.LogInformation("The request asks for {0} pages with {1} in size", request.PageNum, request.PageSize);

        return Task.Run(
            async () => {
                var employees = await employeeService.GetEmployeesAsync(request.PageSize ?? 0, request.PageNum ?? 0, context.CancellationToken);

                var response = new GetEmployeesResponse();
                response.Employees.AddRange(employees.Select(e => EmployeeMapper.Map(e)));

                return response;
            }
        );
    }

    public override Task<CreateEmployeeResponse> CreateEmployee(CreateEmployeeRequest request, ServerCallContext context)
    {
        logger.LogInformation("The request asks for new employee with name {0} and lastname {1}", request.Name, request.Lastname);

        return Task.Run(
            async () => {
                var newEmployee = await employeeService.CreateEmployeeAsync(request.Name, request.Lastname, context.CancellationToken);

                var response = new CreateEmployeeResponse();
                response.Employee = EmployeeMapper.Map(newEmployee);

                return response;
            }
        );
    }
}
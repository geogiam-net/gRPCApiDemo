namespace Demo.gRPCServer.Services;

public static class EmployeeMapper
{
    public static Employee Map(Business.Models.Employee employee)
    {
        return new Employee
        {
            Id = employee.Id.ToString(),
            DocumentId = employee.DocumentId,
            Name = employee.Name,
            Lastname = employee.Lastname,
            Salary = (double)employee.Salary,
            BirthDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(employee.BirthDate.ToUniversalTime()),
            Role = (Role)employee.Role,
            CompanyId = employee.CompanyId.ToString()
        };
    }
}
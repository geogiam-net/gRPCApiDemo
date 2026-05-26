using Grpc.Net.Client;
using Demo.gRPCClient;

Console.WriteLine("Wait until server starts then press any key");
Console.ReadKey();
Console.WriteLine("");

const string serverUrl = "http://localhost:5003";
using var channel = GrpcChannel.ForAddress(serverUrl);

var employeeClient = new ProtoEmployee.ProtoEmployeeClient(channel);

var reply1 = await employeeClient.GetEmployeeByIdAsync(new GetEmployeeByIdRequest { Id = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa" });
Console.WriteLine("Employee is {0} {1} ", reply1.Employee.Name, reply1.Employee.Lastname);
Console.WriteLine();

var reply2 = await employeeClient.GetEmployeesAsync(new GetEmployeesRequest());
foreach (var employee in reply2.Employees)
{
    Console.WriteLine("Employee: {0} {1} has a salary of {2}", employee.Name, employee.Lastname, employee.Salary);
}
Console.WriteLine();

var reply3 = await employeeClient.CreateEmployeeAsync(new CreateEmployeeRequest { Name = "George", Lastname = "Baxter" });
Console.WriteLine("New Employee Id is {0}", reply3.Employee.Id);
Console.WriteLine();

var companyClient = new ProtoCompany.ProtoCompanyClient(channel);

var reply4 = await companyClient.GetCompanyDataAsync(new GetCompanyDataRequest { LegalName = "Acme Manufacturing" });
Console.WriteLine("Company was created on {0} ", reply4.Company.CreationDate);
Console.WriteLine();

var reply5 = await companyClient.UpdateCompanyFinancialsAsync(new UpdateCompanyFinancialsRequest { 
    LegalName = "Acme Manufacturing", NewRevenue = 8426000 , NewEarnings = 250000}
);
Console.WriteLine("Company revenue of {0} and earnings of {1} were updated", reply5.Company.EarningsLastYear, reply5.Company.RevenueLastYear);
Console.WriteLine();

Console.WriteLine("Press any key to exit");

Console.ReadKey();
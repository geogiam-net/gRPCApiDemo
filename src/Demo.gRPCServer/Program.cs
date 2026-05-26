using Demo.gRPCServer.Services;
using Demo.Business.Interfaces;
using Demo.Infrastructure.SqlStorage.Data;
using Demo.Infrastructure.SqlStorage.Services;
using Demo.gRPCServer.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, Demo.Business.Services.EmployeeService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, Demo.Business.Services.CompanyService>();
builder.Services.AddInMemoryDbContext();

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<EmployeeService>();
app.MapGrpcService<CompanyService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    ApplicationDbContext.CreateSeedData(db);
}

app.Run();

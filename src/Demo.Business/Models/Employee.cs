namespace Demo.Business.Models;

public class Employee
{
    public Employee() { }

    public Employee(string name, string lastname)
    {
        Name = name;
        Lastname = lastname;
    }

    public Guid Id { get; set; } = default;

    public string DocumentId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Lastname { get; set; } = string.Empty;

    public decimal Salary { get; set; } = default;

    public DateTime BirthDate { get; set; } = default;

    public Role Role { get; set; } = Role.None;

    public Guid CompanyId { get; set; } = default;
    public Company? Company { get; set; }

}

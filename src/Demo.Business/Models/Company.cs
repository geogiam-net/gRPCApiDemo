namespace Demo.Business.Models;

public class Company
{
    public Company() { }

    public Guid Id { get; set; } = default;

    public Guid CorporationId { get; set; } = default;
    public Corporation? Corporation { get; set; }

    public string LegalName { get; set; } = string.Empty;

    public decimal EarningsLastYear { get; set; } = default;

    public decimal RevenueLastYear { get; set; } = default;

    public DateTime CreationDate { get; set; } = default;

    public List<Employee> Employees { get; set; } = new List<Employee>();

    public List<Location> Locations { get; set; } = new List<Location>();

}

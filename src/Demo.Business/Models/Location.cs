namespace Demo.Business.Models;

public class Location
{
    public Location() { }

    public Guid Id { get; set; } = default;

    public Guid CompanyId { get; set; } = default;
    public Company? Company { get; set; }

    public string Number { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public bool IsHeadquarters { get; set; } = default;

    public bool IsLeased { get; set; } = default;
}

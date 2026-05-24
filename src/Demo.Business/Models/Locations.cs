namespace Demo.Business.Models;

public class Locations
{
    public Locations() { }

    public Guid Id { get; set; } = default;

    public Guid CorporationId { get; set; } = default;
    public Corporation? Corporation { get; set; }

    public string Number { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string ZipCode { get; set; } = string.Empty;

    public bool IsHeadquarters { get; set; } = default;

    public bool IsLeased { get; set; } = default;
}

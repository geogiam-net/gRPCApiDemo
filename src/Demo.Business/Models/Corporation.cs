namespace Demo.Business.Models;

public class Corporation
{
    public Corporation() { }

    public Guid Id { get; set; } = default;

    public string LegalName { get; set; } = string.Empty;

    public List<Company> Companies { get; set; } = new List<Company>();

    public List<Locations> Locations { get; set; } = new List<Locations>();

}

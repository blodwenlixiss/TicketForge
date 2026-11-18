namespace Catalog.Domain.Entity;

public class Venue
{
    private const int NameMaxLength = 50;
    private const int AddressMaxLength = 100;
    private const int CityMaxLength = 50;

    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;

    private Venue()
    {
    }

    public static Venue Create(string name, string address, string city)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Venue name is required.", nameof(name));
        var trimmedName = name.Trim();


        if (trimmedName.Length > NameMaxLength)
            throw new ArgumentException(
                $"Venue name must not exceed {NameMaxLength} characters.",
                nameof(name));

        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Venue address is required.", nameof(address));
        var trimmedAddress = address.Trim();

        if (trimmedAddress.Length > AddressMaxLength)
            throw new ArgumentException(
                $"Venue address must not exceed {AddressMaxLength} characters.",
                nameof(address));

        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("Venue city is required.", nameof(city));

        var trimmedCity = city.Trim();

        if (trimmedCity.Length > CityMaxLength)
            throw new ArgumentException(
                $"Venue city must not exceed {CityMaxLength} characters.",
                nameof(city));

        return new Venue
        {
            Id = Guid.NewGuid(),
            Name = trimmedName,
            Address = trimmedAddress,
            City = trimmedCity
        };
    }
}
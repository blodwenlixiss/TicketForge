using System.ComponentModel.DataAnnotations;
using Catalog.Domain.Enum;

namespace Catalog.Domain.Entity;

public class Event
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public EventStatus Status { get; private set; }
    public Guid VenueId { get; private set; }
    public DateTimeOffset Start { get; private set; }
    public DateTimeOffset End { get; private set; }

    private Event()
    {
    }

    public static Event Create(
        string name,
        string description,
        Guid venueId,
        DateTimeOffset start,
        DateTimeOffset end,
        DateTimeOffset now
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Event name is required.", nameof(name));
        var trimmedName = name.Trim();

        if (trimmedName.Length > 100)
            throw new ArgumentException("Event name must be less than 100 characters.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Event Description is required.", nameof(description));
        var trimmedDescription = description.Trim();

        if (trimmedDescription.Length > 200)
            throw new ArgumentException("Event Description must be less than 200 characters.", nameof(description));

        if (venueId == Guid.Empty)
            throw new ArgumentException("Venue ID is required.", nameof(venueId));

        if (end <= start)
            throw new ArgumentException("Event end must be after its start.", nameof(end));

        if (start < now)
            throw new ArgumentException("Event start must be in the future.", nameof(start));

        return new Event
        {
            Id = Guid.NewGuid(),
            Name = trimmedName,
            Description = trimmedDescription,
            Status = EventStatus.Draft,
            VenueId = venueId,
            Start = start,
            End = end
        };
    }

    public void Publish()
    {
        if (Status != EventStatus.Draft)
            throw new InvalidOperationException(
                "Only draft events can be published.");

        Status = EventStatus.Published;
    }
}
namespace TrackingEntitiesEventsDemo.Data.Entities;

public class Customer : TrackableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}

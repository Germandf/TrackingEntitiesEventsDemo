namespace TrackingEntitiesEventsDemo.Data.Entities;

public class Product : TrackableEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

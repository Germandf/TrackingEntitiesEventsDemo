namespace TrackingEntitiesEventsDemo.Data;

public abstract class TrackableEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; } = "";
    public string? UpdatedBy { get; set; }
}

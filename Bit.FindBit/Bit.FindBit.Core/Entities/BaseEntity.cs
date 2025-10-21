namespace Bit.FindBit.Core.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
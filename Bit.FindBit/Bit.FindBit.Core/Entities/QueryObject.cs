namespace Bit.FindBit.Core.Entities;

public class QueryObject
{
    public string? Query { get; set; } = string.Empty;
    public bool? Picket { get; set; }
    public string? Type { get; set; } = string.Empty;
    public int? Offset { get; set; }
    public int? Limit { get; set; }
}
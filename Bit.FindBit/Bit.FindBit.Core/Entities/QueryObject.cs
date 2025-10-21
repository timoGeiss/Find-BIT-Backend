namespace Bit.FindBit.Core.Entities;

public class QueryObject
{
    public string? Query { get; set; }
    public bool? Picket { get; set; }
    public string? Type { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }
}
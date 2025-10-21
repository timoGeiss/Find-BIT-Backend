using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.Dtos;

public class GeneralResponse
{
    public List<Person> Persons { get; set; } = [];
    public List<Organisation> Organisations { get; set; }  = [];
    public QueryObject queryObject { get; set; } = new();
}
using Bit.FindBit.Core.Entities;

namespace Bit.FindBit.Dtos;

public class GeneralResponse
{
    public List<Organisation> Organisations { get; set; }
    public List<Person> Persons { get; set; }
}
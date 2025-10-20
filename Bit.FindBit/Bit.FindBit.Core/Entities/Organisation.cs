namespace Bit.FindBit.Core.Entities;

public class Organisation : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool Picket { get; set; }
    public string Responsibilities { get; set; } = string.Empty;
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public List<string> Emails { get; set; } = [];
    public List<string> RemedyGroups { get; set; } = [];
    public ICollection<Person> Persons { get; set; } = new List<Person>();
}
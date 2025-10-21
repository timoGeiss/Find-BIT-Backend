namespace Bit.FindBit.Core.Entities;

public class Organisation : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool Picket { get; set; }
    public string Responsibilities { get; set; } = string.Empty;

    // Postgres text[] columns
    public string[] Emails { get; set; } = Array.Empty<string>();
    public string[] RemedyGroups { get; set; } = Array.Empty<string>();

    // Navigation
    public ICollection<Person> Persons { get; set; } = new List<Person>();
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
}
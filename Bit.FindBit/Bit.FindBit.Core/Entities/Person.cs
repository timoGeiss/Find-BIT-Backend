namespace Bit.FindBit.Core.Entities;

public class Person : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ThreemaWorkId { get; set; }
    public string Responsibilities { get; set; } = string.Empty;

    public string[] Emails { get; set; } = Array.Empty<string>();
    public string[] RemedyGroups { get; set; } = Array.Empty<string>();

    // FK -> Organisation
    public Guid OrganisationId { get; set; }
    public Organisation Organisation { get; set; } = null!;

    // Navigation
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
}
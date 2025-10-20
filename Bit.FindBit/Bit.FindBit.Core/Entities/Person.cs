namespace Bit.FindBit.Core.Entities;

public class Person : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string ThreemaWorkId { get; set; } = string.Empty;
    public string Responsibilities { get; set; } = string.Empty;
    public ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
    public List<string> Emails { get; set; } = [];
    public List<string> RemedyGroups { get; set; } = [];
    public Organisation Organisation { get; set; }
}
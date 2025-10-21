using Bit.FindBit.Core.Enums;

namespace Bit.FindBit.Core.Entities;

public class PhoneNumber : BaseEntity
{
    public PhoneNumberType Type { get; set; } 
    public string Number { get; set; } = string.Empty;
    
    public Guid? OrganisationId { get; set; }
    public Organisation? Organisation { get; set; }

    public Guid? PersonId { get; set; }
    public Person? Person { get; set; }
}
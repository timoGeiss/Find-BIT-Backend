using Bit.FindBit.Core.Enums;

namespace Bit.FindBit.Core.Entities;

public class PhoneNumber : BaseEntity
{
    public PhoneNumberType Type { get; set; } 
    public string Number { get; set; } = string.Empty;
}
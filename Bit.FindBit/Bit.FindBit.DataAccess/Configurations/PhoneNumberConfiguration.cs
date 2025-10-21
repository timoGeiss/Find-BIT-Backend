using Bit.FindBit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bit.FindBit.DataAccess.Configurations;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.ToTable("PhoneNumbers", "public");
        builder.HasKey(pn => pn.Id);
        builder.Property(pn => pn.Number).IsRequired().HasMaxLength(100);
        builder.Property(pn => pn.Type).HasConversion<string>();
        
        builder.HasOne(pn => pn.Person)
            .WithMany(p => p.PhoneNumbers)
            .HasForeignKey(pn => pn.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pn => pn.Organisation)
            .WithMany(o => o.PhoneNumbers)
            .HasForeignKey(pn => pn.OrganisationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
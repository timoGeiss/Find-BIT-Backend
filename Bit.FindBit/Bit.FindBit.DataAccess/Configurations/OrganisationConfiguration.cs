using Bit.FindBit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bit.FindBit.DataAccess.Configurations;

public class OrganisationConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder.ToTable("Organisations", "public");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Name).IsRequired().HasMaxLength(200);
        builder.Property(o => o.Picket).HasDefaultValue(false);
        builder.Property(o => o.Responsibilities).HasColumnType("text");

        builder.HasMany(o => o.Persons)
            .WithOne(p => p.Organisation)
            .HasForeignKey(p => p.OrganisationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.PhoneNumbers)
            .WithOne(pn => pn.Organisation)
            .HasForeignKey(pn => pn.OrganisationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
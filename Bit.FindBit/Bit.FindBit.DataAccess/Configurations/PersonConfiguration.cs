using Bit.FindBit.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bit.FindBit.DataAccess.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons", "public");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(150);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(150);
        builder.Property(p => p.ThreemaWorkId).HasMaxLength(100);
        builder.Property(p => p.Responsibilities).HasColumnType("text");

        builder.Property(p => p.Emails).HasColumnType("text[]");
        builder.Property(p => p.RemedyGroups).HasColumnType("text[]");

        builder.HasMany(p => p.PhoneNumbers)
            .WithOne(pn => pn.Person)
            .HasForeignKey(pn => pn.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
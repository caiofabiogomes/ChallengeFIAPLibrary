using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChallengeFIAPLibrary.Domain.Enums;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NameAuthor)
                .IsRequired()
                .HasMaxLength(100);

            builder.OwnsOne(property => property.NameAuthor, nav =>
            {
                nav.Property(n => n.FirstName).HasColumnName("FirstName");
                nav.Property(n => n.LastName).HasColumnName("LastName");
            });

            builder.OwnsOne(property => property.Address);

            builder.OwnsOne(property => property.Email); 

        }
    }
}

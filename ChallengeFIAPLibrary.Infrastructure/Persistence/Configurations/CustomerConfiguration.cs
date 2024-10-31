using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(property => property.Name);

            builder.OwnsOne(property => property.Address);

            builder.OwnsOne(property => property.Email);

            builder.HasMany(e => e.Loans)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);

        }
    }
}

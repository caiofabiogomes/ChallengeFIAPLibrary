using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeFIAPLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChallengeFIAPLibrary.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x => x.BookId);

            builder.OwnsOne(x => x.ValuePerDay);

            builder.OwnsOne(x => x.ValuePerDayLate);

            builder.OwnsOne(x => x.TotalValuePaid);

        }
    }
}

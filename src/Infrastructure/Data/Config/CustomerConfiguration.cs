using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.Address1)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Address2)
                .HasMaxLength(200);

            builder.Property(x => x.Address1)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(85);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.Address1)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.BillingAddress)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.BillingCity)
                .IsRequired()
                .HasMaxLength(85);
        }
    }
}

using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.ProductCode)
                .IsRequired();

            builder.Property(x => x.DescriptionShort)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DescriptionLong)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.ProductSKU)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.ProductStock)
                .IsRequired();

            builder.Property(x => x.PictureUri)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayer.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>//configuration olması için burdan implemente edilmesi gerekir
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);//Id alanı primary key olacak
            builder.Property(x => x.Id).UseIdentityColumn();//Id kolonu birer birer artsın
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");//toplam 18 karakter ve noktadan sonra 2 karakter
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);
            builder.ToTable("Products");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayer.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] ids;

        public CategorySeed(int[] ids)
        {
            this.ids = ids;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category { Id = ids[0], Name = "Kalemler" },
                new Category { Id = ids[1], Name = "Defterler" }
                );
        }
    }
}

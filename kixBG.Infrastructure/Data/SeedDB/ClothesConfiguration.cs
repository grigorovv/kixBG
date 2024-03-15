using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Infrastructure.Data.SeedDB
{
    public class ClothesConfiguration : IEntityTypeConfiguration<Clothe>
    {
        public void Configure(EntityTypeBuilder<Clothe> builder)
        {
            builder.Property(p => p.Price)
                .HasColumnType("Float")
                .HasPrecision(2);
        }
    }
}

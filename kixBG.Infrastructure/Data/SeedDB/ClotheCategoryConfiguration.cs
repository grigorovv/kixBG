using kixBG.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kixBG.Infrastructure.Data.SeedDB
{
    internal class ClotheCategoryConfiguration : IEntityTypeConfiguration<ClotheCategory>
    {
        private bool seed;

        public ClotheCategoryConfiguration(bool _seed)
        {
            seed = _seed;
        }
        public void Configure(EntityTypeBuilder<ClotheCategory> builder)
        {
            if (seed)
            {
                var data = new SeedCategories();

                builder.HasData(new ClotheCategory[]
                {
                data.TShirt,
                data.Belt,
                data.Sweatshirt,
                data.Hat,
                data.Jacket,
                data.Jeans,
                data.Tracksuit,
                data.Other
                });
            }
        }
    }
}
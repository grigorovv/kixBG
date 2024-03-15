using kixBG.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Infrastructure.Data.SeedDB
{
    internal class SeedCategories
    {
        public ClotheCategory TShirt { get; set; }
        public ClotheCategory Jeans { get; set; }
        public ClotheCategory Belt { get; set; }
        public ClotheCategory Hat { get; set; }
        public ClotheCategory Tracksuit { get; set; }
        public ClotheCategory Jacket { get; set; }
        public ClotheCategory Sweatshirt { get; set; }
        public ClotheCategory Other { get; set; }

        public SeedCategories()
        {
            TShirt = new ClotheCategory()
            {
                Id = 1,
                Name = "T-Shirt"
            };
            Jeans = new ClotheCategory()
            {
                Id = 2,
                Name = "Jeans"
            };
            Belt = new ClotheCategory()
            {
                Id = 3,
                Name = "Belt"
            };
            Hat = new ClotheCategory()
            {
                Id = 4,
                Name = "Hat"
            };
            Tracksuit = new ClotheCategory()
            {
                Id = 5,
                Name = "Tracksuit"
            };
            Jacket = new ClotheCategory()
            {
                Id = 6,
                Name = "Jacket"
            };
            Sweatshirt = new ClotheCategory()
            {
                Id = 7,
                Name = "Sweatshirt"
            };
            Other = new ClotheCategory()
            {
                Id = 8,
                Name = "Other"
            };
        }
    }
}

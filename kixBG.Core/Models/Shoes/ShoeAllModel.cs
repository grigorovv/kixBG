using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Models.Shoes
{
    public class ShoeAllModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public int BrandId { get; set; }
    }
}

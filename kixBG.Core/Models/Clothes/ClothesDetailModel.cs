﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Models.Clothes
{
    public class ClothesDetailModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public string Brand { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string? Size { get; set; }
        public int Condition { get; set; }
        public int SellerId { get; set; }
        public string SellerUserId { get; set; }
    }
}

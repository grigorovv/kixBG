﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Core.Models.Clothes
{
    public class ClothesAllModel
    {
        public int Id { get; set; }
        public string ImageURL { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
    }
}

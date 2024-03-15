using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kixBG.Infrastructure.Data.Entities
{
    [Comment("Category of clothing items")]
    public class ClotheCategory
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength()]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public IList<Clothe> Clothes { get; set; } = new List<Clothe>();
    }
}

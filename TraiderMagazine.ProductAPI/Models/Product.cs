using System.ComponentModel.DataAnnotations;

namespace TraiderMagazine.ProductAPI.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1,150000)]
        public double Price { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string CategoryName { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
    }
}

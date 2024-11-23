using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Country { get; set; }
        [Range(1800, 2024)]
        public int FoundedYear { get; set; }
        [Url]
        public string LogoUrl { get; set; }
        [Url]
        public string Website { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<Model> Models { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace CarRendalAPI.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int FoundedYear { get; set; }
        public string LogoUrl { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<Model> Models { get; set; }

    }
}

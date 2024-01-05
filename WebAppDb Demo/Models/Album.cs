using System.ComponentModel.DataAnnotations;

namespace WebAppDb_Demo.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Artist { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(5, 10000)]
        public decimal Price { get; set; } //Double has precision problems
    }
}

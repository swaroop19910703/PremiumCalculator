using System.ComponentModel.DataAnnotations;

namespace PremiumCalculator.Models
{
    public class MemberInput
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(0, 150)]
        public int Age { get; set; }

        [Required]
        public string? DateOfBirth { get; set; } // MM/YYYY

        [Required]
        public string? Occupation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal DeathSumInsured { get; set; }
    }
}

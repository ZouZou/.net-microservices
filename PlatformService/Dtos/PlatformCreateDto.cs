using System.ComponentModel.DataAnnotations;

namespace PlatformService.Dtos
{
    public class PlatformCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Publisher is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Publisher must be between 1 and 100 characters")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [StringLength(50, ErrorMessage = "Cost must not exceed 50 characters")]
        public string Cost { get; set; }
    }
}
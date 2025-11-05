using System.ComponentModel.DataAnnotations;

namespace CommandService.Dtos
{
    public class CommandCreateDto
    {
        [Required(ErrorMessage = "HowTo is required")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "HowTo must be between 1 and 250 characters")]
        public string HowTo { get; set; }

        [Required(ErrorMessage = "CommandLine is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "CommandLine must be between 1 and 500 characters")]
        public string CommandLine { get; set; }
    }
}
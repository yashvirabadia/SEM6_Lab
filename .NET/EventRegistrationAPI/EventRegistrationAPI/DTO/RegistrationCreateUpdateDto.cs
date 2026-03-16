using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI.DTO
{
    public class RegistrationCreateUpdateDto
    {
        [Required, MinLength(3)]
        public string ParticipantName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string EventName { get; set; } = string.Empty;

        [Range(18, 30)]
        public int Age { get; set; }

        public string? DocumentPath { get; set; }

        public IFormFile? DocumentFile { get; set; }


    }
}

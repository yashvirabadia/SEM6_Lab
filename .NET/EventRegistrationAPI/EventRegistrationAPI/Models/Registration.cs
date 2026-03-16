using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace EventRegistrationAPI.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationID { get; set; }

        [Required]
        [MinLength(3)]
        public string ParticipantName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string EventName { get; set; } = string.Empty;

        [Range(18, 30)]
        public int Age { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public string? DocumentPath { get; set; }   // stores uploaded file path
    }

}

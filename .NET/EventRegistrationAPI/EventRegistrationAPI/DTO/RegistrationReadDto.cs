namespace EventRegistrationAPI.DTO
{
    public class RegistrationReadDto
    {
        public int RegistrationID { get; set; }
        public string ParticipantName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EventName { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? DocumentPath { get; set; }
    }
}

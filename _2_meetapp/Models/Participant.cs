using System.ComponentModel.DataAnnotations;

namespace _2_meetapp.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public required bool Coming { get; set; }

        public int MeetingId { get; set; }
    }
}

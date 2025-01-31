namespace _2_meetapp.Models
{
    public class Participant
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required bool Coming { get; set; }
        public int MeetingId { get; set; }
    }
}

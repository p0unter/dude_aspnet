namespace _2_meetapp.Models
{
    public class Repository
    {
        private static readonly List<Meeting> _meetings = new()
        {
            new Meeting() {
                Id = 1,
                Name = "Meeting 1",
                Description = "Meeting 1 Description",
                NumberOfUser = 0
            },
            new Meeting() {
                Id = 2,
                Name = "Meeting 2",
                Description = "Meeting 2 Description",
                NumberOfUser = 0
            },
            new Meeting() {
                Id = 3,
                Name = "Meeting 3",
                Description = "Meeting 3 Description",
                NumberOfUser = 0
            }
        };

        private static List<Participant> _participants = new() { };

        public static List<Meeting> Meetings => _meetings;
        public static List<Participant> Participants => _participants;

        public static Meeting? GetIdMeeting(int id)
        {
            if (id <= 0) return null;
            return _meetings.FirstOrDefault(m => m.Id == id);
        }

        public static void SetNumberOfUser(int id)
        {
            if (id <= 0) return;

            var mts = _meetings.FirstOrDefault(m => m.Id == id);
            if (mts != null)
            {
                _meetings[id - 1].NumberOfUser++;
            }
        }

        public static List<Participant> GetParticipants(int meetingId)
        {
            if (meetingId <= 0) return new List<Participant>();
            return _participants.Where(p => p.MeetingId == meetingId).ToList();
        }

        public static Participant? GetIdParticipant(int id)
        {
            if (id <= 0) return null;
            return _participants.FirstOrDefault(p => p.Id == id);
        }

        public static string AddParticipant(Participant pt, int meetingId)
        {
            if (pt == null) return "Participant cannot be null";
            if (meetingId <= 0) return "Invalid meeting ID";

            var foundMeeting = _meetings.FirstOrDefault(m => m.Id == meetingId);
            if (foundMeeting != null)
            {
                _participants.Add(pt);
                return $"{pt.Name} Added to {foundMeeting.Name}";
            }
            return "Meeting not found";
        }
    }
}
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
                NumberOfUser = 100,
            },
            new Meeting() {
                Id = 2,
                Name = "Meeting 2",
                Description = "Meeting 2 Description",
                NumberOfUser = 150,
            },
            new Meeting() {
                Id = 3,
                Name = "Meeting 3",
                Description = "Meeting 3 Description",
                NumberOfUser = 250,
            }
        };

        private static List<Participant> _participants = new()
        {
            new Participant() {
                Id = 1,
                Name = "Ahmet",
                Email = "info@ahmet.com",
                Phone = "+90 521 321 2312",
                Coming = true,
                MeetingId = 1
            },
            new Participant() {
                Id = 2,
                Name = "Mehmet",
                Email = "info@mehmet.com",
                Phone = "+90 542 321 3212",
                Coming = false,
                MeetingId = 2
            },
            new Participant() {
                Id = 3,
                Name = "Selim",
                Email = "info@selim.com",
                Phone = "+90 555 233 5222",
                Coming = true,
                MeetingId = 3
            }
        };

        public static List<Meeting> Meetings => _meetings;
        public static List<Participant> Participants => _participants;

        public static Meeting? GetIdMeeting(int id)
        {
            return _meetings.FirstOrDefault(m => m.Id == id);
        }

        public static List<Participant> GetParticipants(int meetingId)
        {
            return _participants.Where(p => p.MeetingId == meetingId).ToList();
        }

        public static Participant? GetIdParticipant(int id)
        {
            return _participants.FirstOrDefault(p => p.Id == id);
        }

        public static string AddParticipant(Participant pt, int meetingId)
        {
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
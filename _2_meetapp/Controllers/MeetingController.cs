using _2_meetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_meetapp.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Meetings);
        }

        public IActionResult Detail(int id)
        {
            var detailObj = Repository.GetIdMeeting(id);
            return View(detailObj);
        }

        public IActionResult Participants(int id)
        {
            ViewBag.meetid = id;
            List<Participant> _ptn = Repository.GetParticipants(id);
            foreach (var participant in _ptn)
            {
                Console.WriteLine($"ID: {participant.Id}, Name: {participant.Name}, Email: {participant.Email}, Phone: {participant.Phone}, Coming: {participant.Coming}");
            }
            return View(_ptn);
        }

        public IActionResult Join(int id)
        {
            var detailObj = Repository.GetIdMeeting(id);
            Console.WriteLine(detailObj?.Id);
            return View(detailObj);
        }

        [HttpPost]
        public IActionResult Join(int idm, string name, string email, string phone, bool coming)
        {
            var participant = new Participant
            {
                Id = Repository.Participants.Count + 1,
                Name = name,
                Email = email,
                Phone = phone,
                Coming = coming,
                MeetingId = idm
            };

            var result = Repository.AddParticipant(participant, idm);

            if (result.Contains("Added"))
            {
                return RedirectToAction("Detail", new { id = idm });
            }

            return RedirectToAction("Detail", new { id = idm });
        }
    }
}
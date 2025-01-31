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
            ViewBag.meetidM = id;

            return View();
        }

        [HttpPost]
        public IActionResult Join(Participant ptc, int idm)
        {
            var participant = new Participant
            {
                Id = Repository.Participants.Count + 1,
                Name = ptc.Name,
                Email = ptc.Email,
                Phone = ptc.Phone,
                Coming = ptc.Coming,
                MeetingId = idm
            };

            var result = Repository.AddParticipant(participant, idm);

            if (result.Contains("Added"))
            {
                Repository.SetNumberOfUser(idm);
                return RedirectToAction("Detail", new { id = idm });
            }

            return RedirectToAction("Detail", new { id = idm });
        }

        public IActionResult Thanks(int id)
        {
            var meeting = Repository.GetIdMeeting(id);

            if (meeting == null)
            {
                return NotFound();
            }

            ViewBag.nous = meeting.NumberOfUser;
            ViewBag.idm = id;

            return View();
        }
    }
}
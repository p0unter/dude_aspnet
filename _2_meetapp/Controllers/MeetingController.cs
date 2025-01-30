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
            Console.WriteLine($"Participants method called with meetid: {id}");
            ViewBag.meetid = id;
            List<Participant> _ptn = Repository.GetParticipants(id);
            return View(_ptn);
        }

        public IActionResult Join(int id)
        {
            var detailObj = Repository.GetIdMeeting(id);
            return View(detailObj);
        }

        [HttpPost]
        public IActionResult Join(
            int id,
            string name,
            string email,
            string phone,
            bool coming)
        {
            var participant = new Participant
            {
                Id = Repository.Participants.Count + 1,
                Name = name,
                Email = email,
                Phone = phone,
                Coming = coming,
                MeetingId = id
            };

            var result = Repository.AddParticipant(participant, id);

            if (result.Contains("Added"))
            {
                Console.WriteLine(Repository.Participants);

                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine(Repository.Participants);

                ModelState.AddModelError(string.Empty, result);
                var detailObj = Repository.GetIdMeeting(id);
                return View(detailObj);
            }
        }
    }
}
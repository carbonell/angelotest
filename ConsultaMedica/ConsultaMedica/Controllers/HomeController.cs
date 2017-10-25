using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repository;
using ConsultaMedica.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaMedica.Controllers
{

    public class HomeController : Controller
    {
        private readonly IRepository<ConsultingRoom> _consultingRoomsRepository;

        public HomeController()
        {
            _consultingRoomsRepository = new SqlServerConsultingRoomsRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Doctor")]
        public ActionResult SelectConsultingRoom()
        {
            var userId = User.Identity.GetUserId();

            var doctorConsultinRooms = _consultingRoomsRepository.GetAll(query: x => x.UserId == userId, include: x => x.Clinic);

            ViewBag.ConsultingRooms = doctorConsultinRooms.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Clinic.Name + " - " + x.Name
            }).ToList();

            return View();
        }

        [Authorize(Roles = "Doctor"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult SelectConsultingRoom(SelectConsultingRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var consultingRoom = _consultingRoomsRepository
                    .GetAll(query: x => x.Id == model.Id, include: x => x.Clinic)
                    .FirstOrDefault();

                if (consultingRoom != null)
                {
                    Session["SelectedConsultingRoom"] = string.Format("{0} - {1}", consultingRoom.Clinic.Name, consultingRoom.Name);
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class SelectConsultingRoomViewModel
        {
            public int Id { get; set; }
        }
    }
}
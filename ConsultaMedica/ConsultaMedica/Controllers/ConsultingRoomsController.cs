using ConsultaMedica.Data.Repository;
using ConsultaMedica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsultaMedica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ConsultaMedica.Data;

namespace ConsultaMedica.Controllers
{
    public class ConsultingRoomsController : BaseController
    {
        private readonly IWritableRepository<ConsultingRoom> _consultingRoomsRepository;
        private readonly IRepository<Clinic> _clinicsRepository;
        private readonly IRepository<ApplicationUser> _applicationUsersRepository;
        private readonly RoleManager<IdentityRole> _roleManager;

        // TODO: Implement DI
        public ConsultingRoomsController()
        {
            _consultingRoomsRepository = new SqlServerConsultingRoomsRepository();
            _clinicsRepository = new SqlServerClinicsRepository();
            _applicationUsersRepository = new SqlServerDoctorsRepository();

            // TODO: Encapsulate context.
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DataContext.Create()));
        }

        // GET: Clinics
        public ActionResult Index()
        {
            // TODO: Paginate and search
            var data = _consultingRoomsRepository.GetAll(include: x => x.Clinic).ToList();

            var model = data.Select(x => new ConsultingRoomViewModel { Name = x.Name, ClinicName = x.Clinic.Name });

            return View(model);
        }

        public ActionResult Create()
        {
            var doctorRoleId = _roleManager.Roles.First(x => x.Name == "Doctor").Id;

            ViewBag.Doctors = _applicationUsersRepository
                .GetAll(query: x => x.Roles
                    .Any(r => r.RoleId == doctorRoleId))
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                })
                .ToList();

            ViewBag.Clinics = _clinicsRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            })
            .ToList();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ConsultingRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var consultingRoom = model.ToEntity();

                _consultingRoomsRepository.Create(consultingRoom);

                _consultingRoomsRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}

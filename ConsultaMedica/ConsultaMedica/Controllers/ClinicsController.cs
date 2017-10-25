using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Repository;
using ConsultaMedica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaMedica.Controllers
{
    public class ClinicsController : BaseController
    {
        private readonly IWritableRepository<Clinic> _clinicsRepository;

        // TODO: Implement DI
        public ClinicsController()
        {
            _clinicsRepository = new SqlServerClinicsRepository();
        }

        // GET: Clinics
        public ActionResult Index()
        {
            // TODO: Paginate and search
            var clinics = _clinicsRepository.GetAll();

            var model = clinics.Select(x => new ClinicViewModel { Name = x.Name });

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ClinicViewModel model)
        {
            if (ModelState.IsValid)
            {
                var clinic = new Clinic { Name = model.Name };

                _clinicsRepository.Create(clinic);

                _clinicsRepository.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
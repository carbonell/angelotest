using ConsultaMedica.Data;
using ConsultaMedica.Data.Models;
using ConsultaMedica.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaMedica.Controllers
{
    public class UsersController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationUserManager _userManager;

        public UsersController()
        {
            // TODO: Encapsulate context.
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DataContext.Create()));
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            var doctorRoleId = _roleManager.Roles.First(x => x.Name == "Doctor").Id;

            var doctors = UserManager.Users.Where(x => x.Roles.Any(r => r.RoleId == doctorRoleId)).ToList();

            var model = UserViewModel.FromUserCollection(doctors);

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult CreateDoctor(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };

                var result = UserManager.Create(user, model.Password);

                UserManager.AddToRole(user.Id, "Doctor");

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }
    }
}
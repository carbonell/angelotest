using ConsultaMedica.Data;
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

        [HttpGet]
        public ActionResult Create()
        {
            var roles = _roleManager.Roles.ToList();

            ViewBag.Roles = roles;

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model)
        {
            var roles = _roleManager.Roles.ToList();

            ViewBag.Roles = roles;

            return View();
        }
    }
}
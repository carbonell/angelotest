using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsultaMedica.Data.Models;
using System.Linq;

namespace ConsultaMedica.Models
{
    public class UserViewModel
    {
        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Contrasena")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Confirmación de contrasena")]
        [Required]
        public string PasswordConfirmation { get; set; }

        public string Role { get; set; }

        public static List<UserViewModel> FromUserCollection(List<ApplicationUser> doctors)
        {
            return doctors.Select(x => new UserViewModel
            {
                Email = x.Email,
                Name = x.Name,
                Role = "Doctor" // TODO: Change this
            }).ToList();
        }
    }
}
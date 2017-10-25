using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsultaMedica.Data.Models;
using System.Linq;

namespace ConsultaMedica.Models
{
    public class ClinicViewModel
    {
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        public static List<ClinicViewModel> FromClinicCollection(List<Clinic> clinics)
        {
            return clinics.Select(x => new ClinicViewModel { Name = x.Name }).ToList();
        }
    }
}
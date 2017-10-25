using ConsultaMedica.Data.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace ConsultaMedica.Models
{
    public class ConsultingRoomViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Clínica")]
        public string ClinicName { get; set; }

        [DisplayName("Doctor")]
        public string DoctorName { get; set; }

        [Required]
        [DisplayName("Clínica")]
        public int ClinicId { get; set; }

        // The doctor who belongs to.
        [Required]
        [DisplayName("Doctor")]
        public string UserId { get; set; }

        public ConsultingRoom ToEntity()
        {
            return new ConsultingRoom
            {
                Name = Name,
                ClinicId = ClinicId,
                UserId = UserId
            };
        }
    }
}
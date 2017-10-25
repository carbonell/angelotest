using ConsultaMedica.Data.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultaMedica.Models
{
    public class ConsultingRoomViewModel
    {
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
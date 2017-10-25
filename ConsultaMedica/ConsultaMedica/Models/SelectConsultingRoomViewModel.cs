using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConsultaMedica.Models
{
    public class SelectConsultingRoomViewModel
    {
        [DisplayName("Consultorio")]
        [Required]
        public int Id { get; set; }
    }
}
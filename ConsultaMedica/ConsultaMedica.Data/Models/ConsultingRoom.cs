using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data.Models
{
    public class ConsultingRoom : BaseEntity
    {
        public string Name { get; set; }

        public int ClinicId { get; set; }

        // The doctor who belongs to.
        public string UserId { get; set; }

        // Navigation properties
        public virtual ApplicationUser Doctor { get; set; }

        public virtual Clinic Clinic { get; set; }
    }
}

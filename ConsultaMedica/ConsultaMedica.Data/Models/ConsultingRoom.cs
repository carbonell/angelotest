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
        // TODO: Esto debería ser una asociación de M:M, porque un consultorio al parecer puede pertenecer a más de un doctor :/
        public virtual ApplicationUser Doctor { get; set; }

        public virtual Clinic Clinic { get; set; }
    }

    public class ConsultingRoomApplicationUsersRelationShip : BaseEntity // TODO: Should this inherit from BaseEntity
    {
        public int ConsultingRoomId { get; set; }

        public string UserId { get; set; }
    }
}

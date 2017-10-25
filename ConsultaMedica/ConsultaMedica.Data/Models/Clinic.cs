using ConsultaMedica.Data.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data.Models
{
    public class Clinic : BaseEntity
    {
        public Clinic()
        {
            ConsultingRooms = new HashSet<ConsultingRoom>();
        }

        public string Name { get; set; }

        // navigation properties
        public virtual ICollection<ConsultingRoom> ConsultingRooms { get; set; }
    }
}

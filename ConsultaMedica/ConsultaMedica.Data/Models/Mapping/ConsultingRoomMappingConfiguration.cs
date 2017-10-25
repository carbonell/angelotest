using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data.Models.Mapping
{
    public class ConsultingRoomMappingConfiguration : EntityTypeConfigurationBase<ConsultingRoom>
    {
        public ConsultingRoomMappingConfiguration()
        {
            this.ToTable("ConsultingRooms");

            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.ClinicId).HasColumnName("ClinicId");
            this.Property(x => x.UserId).HasColumnName("UserId");

            this.HasRequired(x => x.Doctor)
                .WithMany(x => x.ConsultingRooms)
                .HasForeignKey(x => x.UserId);

            this.HasRequired(x => x.Clinic)
                .WithMany(x => x.ConsultingRooms)
                .HasForeignKey(x => x.ClinicId);
        }
    }
}

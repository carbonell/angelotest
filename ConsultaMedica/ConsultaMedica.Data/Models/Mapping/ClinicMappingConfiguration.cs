using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data.Models.Mapping
{
    public class ClinicMappingConfiguration : EntityTypeConfigurationBase<Clinic>
    {
        public ClinicMappingConfiguration()
        {
            this.ToTable("Clinics");

            this.Property(x => x.Name).HasColumnName("Name");
        }
    }
}

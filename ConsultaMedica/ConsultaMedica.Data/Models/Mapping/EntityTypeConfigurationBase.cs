using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace ConsultaMedica.Data.Models.Mapping
{
    public class EntityTypeConfigurationBase<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public EntityTypeConfigurationBase()
        {
            this.HasKey(x => x.Id);

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
        }
    }
}

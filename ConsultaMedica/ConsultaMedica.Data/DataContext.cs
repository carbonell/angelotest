using ConsultaMedica.Data.Models;
using ConsultaMedica.Data.Models.Mapping;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaMedica.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.Log = (s) => Debug.WriteLine(s);
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ConsultingRoom> ConsultingRooms { get; set; }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConsultingRoomMappingConfiguration());
            modelBuilder.Configurations.Add(new ClinicMappingConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

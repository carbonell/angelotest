namespace ConsultaMedica.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConsultaMedica.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            // Seed database with clinics and consulting rooms data for test
            
            // TODO: Validate that the user is in Doctor Role.
            
            //var firstUser = context.Users.FirstOrDefault();

            //if (firstUser != null)
            //{
            //    context.Clinics.AddOrUpdate(x => x.Name, new Clinic
            //    {
            //        Name = "Clinica 1"
            //    });

            //    var clinic1 = context.Clinics.FirstOrDefault(x => x.Name == "Clinica 1");

            //    if (clinic1 != null)
            //    {
            //        context.ConsultingRooms.AddOrUpdate(x => x.Name, new ConsultingRoom
            //        {
            //            Name = "Consultorio 1",
            //            ClinicId = clinic1.Id,
            //            UserId = firstUser.Id
            //        });
            //    }
            //}

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

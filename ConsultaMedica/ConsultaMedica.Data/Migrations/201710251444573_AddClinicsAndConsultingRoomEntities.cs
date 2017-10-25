namespace ConsultaMedica.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClinicsAndConsultingRoomEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConsultingRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClinicId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinics", t => t.ClinicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ClinicId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConsultingRooms", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConsultingRooms", "ClinicId", "dbo.Clinics");
            DropIndex("dbo.ConsultingRooms", new[] { "UserId" });
            DropIndex("dbo.ConsultingRooms", new[] { "ClinicId" });
            DropTable("dbo.ConsultingRooms");
            DropTable("dbo.Clinics");
        }
    }
}

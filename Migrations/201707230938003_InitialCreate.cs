namespace WebApplication9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        NurseID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .ForeignKey("dbo.Nurses", t => t.NurseID, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientID, cascadeDelete: true)
                .Index(t => t.DoctorID)
                .Index(t => t.NurseID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.DoctorID);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        NurseID = c.Int(nullable: false, identity: true),
                        NurseName = c.String(),
                    })
                .PrimaryKey(t => t.NurseID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Bookings", "NurseID", "dbo.Nurses");
            DropForeignKey("dbo.Bookings", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Bookings", new[] { "PatientID" });
            DropIndex("dbo.Bookings", new[] { "NurseID" });
            DropIndex("dbo.Bookings", new[] { "DoctorID" });
            DropTable("dbo.Patients");
            DropTable("dbo.Nurses");
            DropTable("dbo.Doctors");
            DropTable("dbo.Bookings");
        }
    }
}

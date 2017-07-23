using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication9.Bookings;
using WebApplication9.Doctors;
using WebApplication9.Models;
using WebApplication9.Nurses;
using WebApplication9.Patients;

namespace WebApplication9.Context
{
    public class HospitalContext : DbContext
    {

        public HospitalContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        

        public System.Data.Entity.DbSet<WebApplication9.Bookings.Booking> Bookings { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Doctors.Doctor> Doctors { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Nurses.Nurse> Nurses { get; set; }

        public System.Data.Entity.DbSet<WebApplication9.Patients.Patient> Patients { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication9.Bookings;

namespace WebApplication9.Doctors
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        public string DoctorName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
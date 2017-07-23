using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication9.Bookings;

namespace WebApplication9.Patients
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string PatientName { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
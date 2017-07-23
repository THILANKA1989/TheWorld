using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Bookings
{
    public class BookingViewModel
    {
        public int BookingID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        public int NurseID { get; set; }

        [Required]
        public int PatientID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication9.Doctors;
using WebApplication9.Nurses;
using WebApplication9.Patients;

namespace WebApplication9.Bookings
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        
        public int DoctorID{ get; set; }
        [ForeignKey("DoctorID")]
        public virtual Doctor Doctor { get; set; }

        
        public int NurseID { get; set; }
        [ForeignKey("NurseID")]
        public virtual Nurse Nurse { get; set; }
        
        
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual Patient Patient { get; set; }


    }
}
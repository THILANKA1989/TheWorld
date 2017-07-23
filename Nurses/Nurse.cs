using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication9.Bookings;

namespace WebApplication9.Nurses
{
    public class Nurse
    {
        [Key]
        public int NurseID { get; set; }

        public string NurseName { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
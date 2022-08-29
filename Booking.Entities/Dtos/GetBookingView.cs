using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Dtos
{
    public class GetBookingView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }      
        public string Name { get; set; }
        public string StartAt { get; set; }
        public string FinishAt { get; set; }
        public int Confirmed { get; set; }
    }
}

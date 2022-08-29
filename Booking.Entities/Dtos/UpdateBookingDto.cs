using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Dtos
{
    public class UpdateBookingDto
    {
        
        public int Id { get; set; }
       
        public int UserId { get; set; }
       
        public string StartAt { get; set; }
    
        public string BookingAt { get; set; }
     
        public int BookingFor { get; set; }
      
        public int ApartmentId { get; set; }
      
        public int Confirmed { get; set; }
    }
}

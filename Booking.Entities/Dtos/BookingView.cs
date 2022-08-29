using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Dtos
{
    public  class BookingView : IEntity
    {
        public string FirstName { get; set; }        
        public string LastName { get; set; }    
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string StartAt { get; set; }
        public string FinishAt { get; set; }
        public int Confirmed { get; set; }
        public int userId { get; set; }
        public int apartmentId { get; set; }
        public int Id { get; set; }

    }
}

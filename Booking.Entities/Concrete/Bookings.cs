using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Concrete
{
    [Table("Bookings")]
    public class Bookings : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0)]
        public int Id { get; set; }
        [Column("UserId", Order = 1)]
        public int UserId { get; set; }
        [Column("StartAt", Order = 2)]
        public string StartAt { get; set; }
        [Column("BookingAt", Order = 3)]
        public string BookingAt { get; set; }
        [Column("BookingFor", Order = 4)]
        public int BookingFor { get; set; }
        [Column("ApartmentId", Order = 5)]
        public int ApartmentId { get; set; }
        [Column("Confirmed", Order = 6)]
        public int Confirmed { get; set; }       
    }
}

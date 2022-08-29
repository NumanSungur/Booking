using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Concrete
{
    [Table("Appartments")]
    public class Appartments : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0)]
        public int Id { get; set; }
        [Column("Name", Order = 1)]
        public string Name { get; set; }
        [Column("Image", Order = 2)]
        public string Image { get; set; }
        [Column("Country", Order = 3)]
        public string Country { get; set; }
        [Column("City", Order = 4)]
        public string City { get; set; }
        [Column("ZipCode", Order = 5)]
        public string ZipCode { get; set; }
        [Column("Address", Order = 6)]
        public string Address { get; set; }
        [Column("Address2", Order = 7)]
        public string Address2 { get; set; }
        [Column("Latitude", Order = 8)]
        public double Latitude { get; set; }
        [Column("Longitude", Order = 9)]
        public double Longitude { get; set; }
        [Column("Direction", Order = 10)]
        public string Direction { get; set; }
        [Column("Booked", Order = 11)]
        public int Booked { get; set; }
    }
}

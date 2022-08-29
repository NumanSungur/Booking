using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Entities.Concrete
{
    [Table("Users")]
    public class Users : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id", Order = 0)]
        public int Id { get; set; }
        [Column("FirstName", Order = 1)]
        public string FirstName { get; set; }
        [Column("LastName", Order = 2)]
        public string LastName { get; set; }
        [Column("FullName", Order = 3)]
        public string FullName { get; set; }
        [Column("JobTitle", Order = 4)]
        public string JobTitle { get; set; }
        [Column("JobType", Order = 5)]
        public string JobType { get; set; }
        [Column("Phone", Order = 6)]
        public string Phone { get; set; }
        [Column("Email", Order = 7)]
        public string Email { get; set; }
        [Column("Image", Order = 8)]
        public string Image { get; set; }
        [Column("Country", Order = 9)]
        public string Country { get; set; }
        [Column("City", Order = 10)]
        public string City { get; set; }
        [Column("OnboardingCompletion", Order = 11)]
        public int OnboardingCompletion { get; set; }
    }
}

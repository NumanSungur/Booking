using Booking.DataAccess.Abstract;
using Booking.DataAccess.Concrete.EntityFramework.Contexts;
using Booking.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users,BookingContext>,IUserDal
    {
    }
}

using Booking.Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataAccess.Abstract
{
    public interface IAppartmentDal : IEntityRepository<Appartments>
    {
    }
}

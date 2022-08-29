using Autofac;
using Booking.Business.Abstract;
using Booking.Business.Concrete;
using Booking.DataAccess.Abstract;
using Booking.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookingManager>().As<IBookingService>();
            builder.RegisterType<EfBookingDal>().As<IBookingDal>();
            builder.RegisterType<EfAppartmentDal>().As<IAppartmentDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}

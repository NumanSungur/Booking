using Booking.Entities.Concrete;
using Booking.Entities.Dtos;
using Core.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Business.Abstract
{
    public interface IBookingService
    {
        Task<IDataResult<List<BookingView>>> GetAll();
        Task<IDataResult<List<BookingView>>> GetAll(string? filter, int offset = 0, int limit = 10);
        Task<IDataResult<GetBookingView>> Get(GetDto model);
        Task<IResult> Add(Bookings model);
        Task<IResult> Update(UpdateBookingDto model);
        Task<IResult> Delete(DeleteDto model);
    }
}

using Booking.Business.Abstract;
using Booking.Business.Helper;
using Booking.DataAccess.Abstract;
using Booking.Entities.Concrete;
using Booking.Entities.Dtos;
using Core.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Business.Concrete
{
    public class BookingManager : IBookingService
    {
        private IBookingDal _bookingDal;
        private IAppartmentDal _appartmentDal;
        private IUserDal _userDal;
        public BookingManager(IBookingDal bookingDal, IAppartmentDal appartmentDal, IUserDal userDal) 
        { 
            _bookingDal = bookingDal;
            _appartmentDal = appartmentDal;
            _userDal = userDal;
        }
        public async Task<IResult> Add(Bookings model)
        {
            await _bookingDal.AddAsync(model);
            return new SuccessResult(true, "Booking added successfully");
        }

        public async Task<IResult> Delete(DeleteDto model)
        {
            Bookings bookings = await _bookingDal.GetAsync(s => s.Id == model.Id);

            if (bookings.Confirmed == 0)
            {
                await _bookingDal.DeleteAsync(bookings);
                return new SuccessResult(true, "Booking deleted successfully");
            }
            return new ErrorResult("Getting trouble when deleted booking");
        }

        public async Task<IDataResult<GetBookingView>> Get(GetDto model)
        {
            Bookings bookings = await _bookingDal.GetAsync(s => s.Id == model.Id);
            var finishAt = Convert.ToDateTime(bookings.StartAt.ToString() + bookings.BookingFor);
            var startAt = Convert.ToDateTime(bookings.StartAt.ToString());
            if (bookings != null || startAt.ToShortDateString() != null && finishAt.ToShortDateString != null)
            {
                Appartments appartments = await _appartmentDal.GetAsync(s => s.Id == bookings.ApartmentId);
                Users users = await _userDal.GetAsync(s => s.Id == bookings.UserId);

                GetBookingView getBookingView = new GetBookingView();
                getBookingView.FirstName = users.FirstName;
                getBookingView.LastName = users.LastName;
                getBookingView.Name = appartments.Name;
                getBookingView.FinishAt = finishAt.ToString();
                getBookingView.StartAt = startAt.ToString();
                getBookingView.Confirmed = bookings.Confirmed;

                return new SuccessDataResult<GetBookingView>(getBookingView, message: "Liste Başarılı");
            }
            return new ErrorDataResult<GetBookingView>(message: "Bad Request");
        }

        public async Task<IDataResult<List<BookingView>>> GetAll()
        {
            List<Bookings> bookings = await _bookingDal.GetListAsync(s => s.Confirmed == 1);
            var finishAt = Convert.ToDateTime(bookings.FirstOrDefault(s => s.Confirmed == 1).StartAt.ToString() + bookings.FirstOrDefault(s => s.Confirmed == 1).BookingFor);
            var startAt = Convert.ToDateTime(bookings.FirstOrDefault(s => s.Confirmed == 1).StartAt.ToString());
            List<BookingView> bookingsView = new List<BookingView>();
            foreach (var item in bookingsView)
            {
                Appartments appartments = await _appartmentDal.GetAsync(s => s.Id == item.apartmentId);
                Users users = await _userDal.GetAsync(s => s.Id == item.userId);
                if (appartments != null && users != null)
                {
                    bookingsView.Add(new BookingView
                    {
                        Id = item.Id,
                        userId = users.Id,
                        apartmentId = appartments.Id,
                        Address = appartments.Address,
                        FirstName = users.FirstName,
                        LastName = users.LastName,
                        Email = users.Email,
                        Phone = users.Phone,
                        Name = appartments.Name,
                        Country = appartments.Country,
                        City = appartments.City,
                        ZipCode = appartments.ZipCode,
                        StartAt = item.StartAt,
                        FinishAt = finishAt.ToString(),
                        Confirmed = item.Confirmed
                    });
                }
            }
            return new SuccessDataResult<List<BookingView>>(bookingsView.ToList(), message: "Liste Başarılı");
        }

        public async Task<IDataResult<List<BookingView>>> GetAll(string? filter, int offset = 0, int limit = 10)
        {
            List<Bookings> bookings = null;
            if (!string.IsNullOrWhiteSpace(filter))
                bookings = (await _bookingDal.GetListAsync(s => s.Confirmed == 1)).Where(x => (Check.Checker(x.Id.ToString(), filter) || Check.Checker(x.UserId.ToString(), filter) || Check.Checker(x.ApartmentId.ToString(), filter) || Check.Checker(x.StartAt, filter) || Check.Checker(x.BookingAt, filter) || Check.Checker(x.Confirmed.ToString(), filter) || Check.Checker(x.BookingFor.ToString(), filter))).OrderBy(x => x.StartAt).Skip(offset).Take(limit).ToList();
            else bookings = await _bookingDal.GetListAsync(s => s.Confirmed == 1);
            var finishAt = Convert.ToDateTime(bookings.FirstOrDefault(s => s.Confirmed == 1).StartAt.ToString() + bookings.FirstOrDefault(s => s.Confirmed == 1).BookingFor);
            List<BookingView> bookingsView = new List<BookingView>();
            foreach (var item in bookingsView)
            {
                Appartments appartments = await _appartmentDal.GetAsync(s => s.Id == item.apartmentId);
                Users users = await _userDal.GetAsync(s => s.Id == item.userId);
                if (appartments != null && users != null)
                {
                    bookingsView.Add(new BookingView
                    {
                        Id = item.Id,
                        userId = users.Id,
                        apartmentId = appartments.Id,
                        Address = appartments.Address,
                        FirstName = users.FirstName,
                        LastName = users.LastName,
                        Email = users.Email,
                        Phone = users.Phone,
                        Name = appartments.Name,
                        Country = appartments.Country,
                        City = appartments.City,
                        ZipCode = appartments.ZipCode,
                        StartAt = item.StartAt,
                        FinishAt = finishAt.ToString(),
                        Confirmed = item.Confirmed
                    });
                }
            }
            if (!string.IsNullOrWhiteSpace(filter))
                return new SuccessDataResult<List<BookingView>>(bookingsView.Where(x => x.Confirmed == 1 && (Check.Checker(x.Id.ToString(), filter) || Check.Checker(x.userId.ToString(), filter) || Check.Checker(x.apartmentId.ToString(), filter) || Check.Checker(x.StartAt, filter) || Check.Checker(x.FinishAt, filter) || Check.Checker(x.Confirmed.ToString(), filter) || Check.Checker(x.Address, filter) || Check.Checker(x.FirstName, filter) || Check.Checker(x.LastName, filter) || Check.Checker(x.Email, filter) || Check.Checker(x.Phone, filter) || Check.Checker(x.Name, filter) || Check.Checker(x.Country, filter) || Check.Checker(x.City, filter) || Check.Checker(x.ZipCode, filter))).OrderBy(x=>x.StartAt).Skip(offset).Take(limit).ToList());
            return new SuccessDataResult<List<BookingView>>(bookingsView.Where(x => x.Confirmed == 1).OrderBy(x => x.StartAt).Skip(offset).Take(limit).ToList());
        }
        public async Task<IResult> Update(UpdateBookingDto model)
        {
            Bookings bookings = await _bookingDal.GetAsync(s => s.Id == model.Id);

            if (bookings != null)
            {
                bookings.UserId = model.UserId;
                bookings.StartAt = model.StartAt;
                bookings.BookingAt = model.BookingAt;
                bookings.ApartmentId = model.ApartmentId;
                bookings.BookingFor = model.BookingFor;
                bookings.Confirmed = model.Confirmed;
                await _bookingDal.UpdateAsync(bookings);
                return new SuccessResult(true, "Booking updated successfully");
            }
            else
            {
                return new ErrorResult("Getting trouble when updated booking");
            }           
        }
    }
}

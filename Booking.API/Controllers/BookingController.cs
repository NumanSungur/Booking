using Booking.Business.Abstract;
using Booking.Entities.Concrete;
using Booking.Entities.Dtos;
using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost(template: "CreateBooking")]
        public async Task<IActionResult> CreateBooking(Bookings newBooking)
        {
            var result = await _bookingService.Add(newBooking);

            if (result.Success)
            {
                return CreatedAtAction(nameof(GetBy), new GetDto { Id = newBooking.Id }, newBooking);
            }

            return BadRequest(result.Message);
        }

        [HttpPut(template: "UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBooking)
        {
            var result = await _bookingService.Update(updateBooking);

            if (result.Success)
            {
                return Ok(updateBooking);
            }

            return BadRequest(result.Message);
        }

        [HttpDelete(template: "DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(DeleteDto deleteBooking)
        {
            var result = await _bookingService.Delete(deleteBooking);

            if (result.Success)
            {
                return Ok(deleteBooking);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _bookingService.GetAll();

            if (result.Success)
            {
                if (result.Data.Count == 0)
                    return NoContent();

                return Ok(result.Data);
            }

            return BadRequest();

        }

        [HttpGet(template: "Get")]
        public async Task<IActionResult> Get(string? filter, int offset = 0, int limit = 10)
        {
            if (limit > 100)
                return BadRequest("Limit can not be greater than 100");

            var result = await _bookingService.GetAll(filter, offset, limit);

            if (result.Data.Count == 0)
                return NoContent();

            if (result.Success)
                return Ok(result.Data);

            return BadRequest();

        }

        [HttpGet(template: "GetBy")]
        public async Task<IActionResult> GetBy([FromQuery] GetDto getBooking)
        {
            var result = await _bookingService.Get(getBooking);

            if (result.Success)
            {
                if (result.Data == null)
                    return NoContent();

                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}

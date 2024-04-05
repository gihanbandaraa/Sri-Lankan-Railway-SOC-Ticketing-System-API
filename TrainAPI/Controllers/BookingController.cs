using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrainAPI.Data;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller {
        private readonly BookingRepository _bookingRepository;
        private readonly IMapper mapper;

        public BookingController(BookingRepository bookingRepository,IMapper _mapper)
        {
            _bookingRepository = bookingRepository;
            mapper = _mapper;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookSeats(BookingCreateDTO request)
        {
            var result = await _bookingRepository.BookSeatsAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("BookedSeats")]
        public IActionResult GetBookedSeats(string TrainId, string Date)
        {
            var bookedSeats = _bookingRepository.GetBookedSeats(TrainId, Date);
            if (bookedSeats != null)
            {
                return Ok(bookedSeats);
            }
            else
            {
                return StatusCode(500, "Failed to retrieve booked seats.");
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<BookingReadDTO>> GetAllUsers()
        {
            var users = _bookingRepository.GetAllBookings();
            return Ok(mapper.Map<IEnumerable<BookingReadDTO>>(users));
        }

        [HttpGet("{ID}", Name = "GetByBookingID")]
        public ActionResult<BookingReadDTO> GetBookings(int ID)
        {
            var booking = _bookingRepository.GetBookings(ID);
            if (booking != null)
            {
                return Ok(mapper.Map<BookingReadDTO>(booking));
            }
            else
            {
                return NoContent(); 
            }
        }

        [HttpDelete("{ID}")]
        public ActionResult DeleteBook(int ID)
        {
            var booking = _bookingRepository.GetBookings(ID);
            if (booking != null)
            {
                _bookingRepository.RemoveBooking(booking);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


    }
}

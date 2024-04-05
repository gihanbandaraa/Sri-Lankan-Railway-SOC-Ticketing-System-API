using System;
using System.Linq;
using System.Threading.Tasks;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Data
{
    public class BookingRepository
    {
        private AppDBContext _dbContext;

        public BookingRepository(AppDBContext context)
        {
            _dbContext = context;
        }

        public async Task<BookingResult> BookSeatsAsync(BookingCreateDTO request)
        {
            try
            {
                var existingBookings = _dbContext.Bookings
                    .Where(b => b.TrainId == request.TrainId && b.Date == request.Date)
                    .ToList();

                var bookedSeatNumbers = existingBookings.SelectMany(b => b.Seats).ToList();
                var availableSeats = request.Seats.Except(bookedSeatNumbers).ToList();

                if (availableSeats.Any())
                {
                                 
                    var booking = new Booking
                    {
                        TrainId = request.TrainId,
                        Date = request.Date,
                        Seats = availableSeats
                    };

                    _dbContext.Bookings.Add(booking);
                    await _dbContext.SaveChangesAsync();
                    return new BookingResult { IsSuccess = true, Message = "Booking successful." };
                }
                else
                {
                    return new BookingResult { IsSuccess = false, Message = "Requested seats are already booked." };
                }
            }
            catch (Exception ex)
            {
           
                Console.WriteLine($"Failed to book seats: {ex.Message}");
                return new BookingResult { IsSuccess = false, Message = $"Failed to book seats: {ex.Message}" };
            }
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<BookedSeatDTO> GetBookedSeats(string trainId, string date)
        {
            try
            {
                return _dbContext.Bookings
                    .Where(b => b.TrainId == trainId && b.Date == date)
                    .Select(b => new BookedSeatDTO
                    {
                        SeatNumbers = b.Seats 
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to retrieve booked seats: {ex.Message}");
                return null;
            }
        }

        public Booking GetBookings(int id)
        {
            return _dbContext.Bookings.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _dbContext.Bookings.ToList();
        }

        public bool RemoveBooking(Booking booking)
        {
            _dbContext.Bookings.Remove(booking);
            return Save();
        }

    }
}

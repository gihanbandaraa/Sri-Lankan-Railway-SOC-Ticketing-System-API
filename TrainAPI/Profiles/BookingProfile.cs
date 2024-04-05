using TrainAPI.DTO;
using TrainAPI.Model;
using AutoMapper;

namespace TrainAPI.Profiles
{
    public class BookingProfile:Profile
    {

        public BookingProfile()
        {
            CreateMap<Booking, BookingReadDTO>();
            CreateMap<BookingProfile, Booking>();
        }
    }
}

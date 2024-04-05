using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Profiles
{
    public class BookedUserProfile: Profile
    {
        public BookedUserProfile()
        {
            CreateMap<BookedUsers, BookedUserReadDTO>();
            CreateMap<BookedUserCreateDTO, BookedUsers>();
        }
    }
}

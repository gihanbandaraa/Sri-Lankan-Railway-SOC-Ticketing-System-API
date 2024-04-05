using AutoMapper;
using TrainAPI.Model;
using TrainAPI.DTO;


namespace TrainAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<Users, UserReadDTO>();
            CreateMap<UserCreateDTO, Users>();
        }
    }
}

using TrainAPI.DTO;
using TrainAPI.Model;
using AutoMapper;

namespace TrainAPI.Profiles
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminReadDTO>();
            CreateMap<AdminCreateDTO, Admin>();
        }
    }
}

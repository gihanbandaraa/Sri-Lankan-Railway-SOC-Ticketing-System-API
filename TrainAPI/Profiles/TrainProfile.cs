using AutoMapper;
using TrainAPI.Model;
using TrainAPI.DTO;


namespace TrainAPI.Profiles
{
    public class TrainProfile :Profile
    {
        public TrainProfile() 
        {
            CreateMap<Train, TrainReadDTO>();
            CreateMap<TrainCreateDTO, Train>();
        }


    }
}

using AdoPet_Api.Data.Dto;
using AdoPet_Api.Model;
using AutoMapper;

namespace AdoPet_Api.Profiles
{
    public class TutorProfile : Profile
    {
        public TutorProfile()
        {
            CreateMap<CreateTutorDto, TutorModel>();
            CreateMap<UpdateTutorDto, TutorModel>();
            CreateMap<TutorModel, UpdateTutorDto>();
            CreateMap<TutorModel, ReadTutorDto>();
        }
    }
}

using AdoPet_Api.Data.Dto;
using AdoPet_Api.Model;
using AutoMapper;

namespace AdoPet_Api.Profiles
{
    public class ShelterProfile : Profile
    {
        public ShelterProfile()
        {
            CreateMap<CreateShelterDto, ShelterModel>();
            CreateMap<UpdateShelterDto, ShelterModel>();
            CreateMap<ShelterModel, UpdateShelterDto>();
            CreateMap<ShelterModel, ReadShelterDto>();
        }
    }
}

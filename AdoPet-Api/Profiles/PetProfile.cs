
using AdoPet_Api.Data.Dto;
using AdoPet_Api.Model;
using AutoMapper;

namespace AdoPet_Api.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetDto, PetModel>();
            CreateMap<UpdatePetDto, PetModel>();
            CreateMap<PetModel, UpdatePetDto>();

            CreateMap<ShelterModel, ReadShelterDto>();

            CreateMap<PetModel, ReadPetDto>()
                .ForMember(petDto => petDto.Shelters,
                    opt => opt.MapFrom(petModel => new ReadShelterDto
                    {
                        Nome = petModel.Shelter.Nome,
                        Cidade = petModel.Shelter.Cidade,
                        Estado = petModel.Shelter.Estado
                    }));
        }
    }

}

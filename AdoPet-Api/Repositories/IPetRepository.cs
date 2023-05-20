using AdoPet_Api.Model;

namespace AdoPet_Api.Repositories
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetPets();

        Task<Pet> GetPetById(int id);

        Task<Pet> CreatePet(Pet Pet);

        Task<Pet> UpdatePet(Pet Pet, int id);

        Task<bool> DeletePet(int id);
    }
}

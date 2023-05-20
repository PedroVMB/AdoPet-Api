using AdoPet_Api.Model;

namespace AdoPet_Api.Repositories
{
    public interface IShelterRepository
    {
        Task<List<Shelter>> GetShelters();

        Task<Shelter> GetShelterById(int id);

        Task<Shelter> CreateShelter(Shelter Shelter);

        Task<Shelter> UpdateShelter(Shelter Shelter, int id);

        Task<bool> DeleteShelter(int id);
    }
}

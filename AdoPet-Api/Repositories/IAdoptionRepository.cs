using AdoPet_Api.Model;

namespace AdoPet_Api.Repositories
{
    public interface IAdoptionRepository
    {
        Task<Adoption> NewAdoption(int petId, int tutorId);

        Task<bool> CancelAdoption(Guid id);
    }
}

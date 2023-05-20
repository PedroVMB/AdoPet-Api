using AdoPet_Api.Model;

namespace AdoPet_Api.Repositories
{
    public interface ITutorRepository
    {
        Task<List<Tutor>> GetTutors();

        Task<Tutor> GetTutorById(int id);

        Task<Tutor> CreateTutor(Tutor tutor);

        Task<Tutor> UpdateTutor(Tutor tutor, int id);

        Task<bool> DeleteTutor(int id);

    }
}

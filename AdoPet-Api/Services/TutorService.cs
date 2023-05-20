using AdoPet_Api.Data;
using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Services
{
    public class TutorService : ITutorRepository
    {
        private readonly AdoPetContext _dbContext; 

        public TutorService(AdoPetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tutor>> GetTutors()
        {
            return await _dbContext.Tutores.ToListAsync();
        }

        public async Task<Tutor> GetTutorById(int id)
        {
            return await _dbContext.Tutores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tutor> CreateTutor(Tutor tutor)
        {
            _dbContext.Tutores.Add(tutor);
            _dbContext.SaveChanges();

            return tutor;
        }

        public async Task<Tutor> UpdateTutor(Tutor tutor, int id)
        {
            Tutor tutorId = await GetTutorById(id);

            if (tutorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }
            tutorId.Nome = tutor.Nome;
            tutorId.Telefone = tutor.Telefone;
            tutorId.Cidade = tutor.Cidade;
            tutorId.Descricao = tutor.Descricao;


            _dbContext.Tutores.Update(tutorId);
            _dbContext.SaveChanges();

            return tutorId;
        }

        public async Task<bool> DeleteTutor(int id)
        {
            Tutor tutorId = await GetTutorById(id);

            if (tutorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            _dbContext.Tutores.Remove(tutorId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}

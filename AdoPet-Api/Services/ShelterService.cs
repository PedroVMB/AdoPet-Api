using AdoPet_Api.Data;
using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Services
{
    public class ShelterService : IShelterRepository
    {
        private readonly AdoPetContext _dbContext;

        public ShelterService(AdoPetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Shelter>> GetShelters()
        {
            return await _dbContext.Shelters.ToListAsync();
        }

        public async Task<Shelter> GetShelterById(int id)
        {
            return await _dbContext.Shelters.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Shelter> CreateShelter(Shelter Shelter)
        {
            _dbContext.Shelters.Add(Shelter);
            _dbContext.SaveChanges();

            return Shelter;
        }

        public async Task<Shelter> UpdateShelter(Shelter Shelter, int id)
        {
            Shelter ShelterId = await GetShelterById(id);

            if (ShelterId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }
            ShelterId.Nome = Shelter.Nome;
            ShelterId.Cidade = Shelter.Cidade;
            ShelterId.Estado = Shelter.Estado;


            _dbContext.Shelters.Update(ShelterId);
            _dbContext.SaveChanges();

            return ShelterId;
        }

        public async Task<bool> DeleteShelter(int id)
        {
            Shelter ShelterId = await GetShelterById(id);

            if (ShelterId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            _dbContext.Shelters.Remove(ShelterId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}

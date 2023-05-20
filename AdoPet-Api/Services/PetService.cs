using AdoPet_Api.Data;
using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Services
{
    public class PetService : IPetRepository
    {
        private readonly AdoPetContext _dbContext;
        public PetService(AdoPetContext context)
        {
            _dbContext = context;
        }

        public async Task<List<Pet>> GetPets()
        {
            return await _dbContext.Pets.Include(x => x.Shelter).ToListAsync();
        }
        public async Task<Pet> GetPetById(int id)
        {
            return await _dbContext.Pets.Include(x => x.Shelter).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pet> CreatePet(Pet Pet)
        {
            _dbContext.Pets.Add(Pet);
            _dbContext.SaveChanges();

            return Pet;
        }

        public async Task<Pet> UpdatePet(Pet Pet, int id)
        {
            Pet PetId = await GetPetById(id);

            if (PetId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }
            PetId.Nome = Pet.Nome;
            PetId.Descricao = Pet.Descricao;
            PetId.Adotado = Pet.Adotado;
            PetId.Idade = Pet.Idade;
            PetId.Endereco = Pet.Endereco;
            PetId.Imagem = Pet.Imagem;
            PetId.ShelterId = Pet.ShelterId;


            _dbContext.Pets.Update(PetId);
            _dbContext.SaveChanges();

            return PetId;
        }

        public async Task<bool> DeletePet(int id)
        {
            Pet PetId = await GetPetById(id);

            if (PetId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado");
            }

            _dbContext.Pets.Remove(PetId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}

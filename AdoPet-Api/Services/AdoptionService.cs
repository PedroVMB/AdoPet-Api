using AdoPet_Api.Data;
using AdoPet_Api.Model;
using AdoPet_Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdoPet_Api.Services
{
    public class AdoptionService : IAdoptionRepository
    {
        private readonly AdoPetContext _context;
        public AdoptionService(AdoPetContext context)
        {
            _context = context;
        }

        public async Task<bool> CancelAdoption(Guid id)
        {
            var adoption = await _context.Adoptions.FindAsync(id);

            if (adoption == null)
            {
                throw new Exception($"Adoção com ID {id} não foi encontrada");
            }

            var pet = await _context.Pets.FindAsync(adoption.PetId);

            if (pet == null)
            {
                throw new Exception($"Pet com ID {adoption.PetId} não foi encontrado");
            }

            pet.Adotado = false;

            _context.Adoptions.Remove(adoption);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Adoption> NewAdoption(int petId, int tutorId)
        {
            var pet = await _context.Pets.FindAsync(petId);

            if (pet == null)
            {
                throw new Exception($"Pet com ID {petId} não foi encontrado");
            }

            pet.Adotado = true;

            var adoption = new Adoption
            {
                PetId = petId,
                TutorId = tutorId,
                DateTime = DateTime.Now
            };

            _context.Adoptions.Add(adoption);
            await _context.SaveChangesAsync();

            return adoption;
        }
    }
}
